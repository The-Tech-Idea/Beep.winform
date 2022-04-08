using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.DataManagement
{
    public class DataManager
    {
        public DataManager(IDMEEditor pDMEEditor, string dataviewname)
        {
              DataviewName=dataviewname;
              DMEEditor = pDMEEditor;
             Data = new DataSet();
        }
        public IDMEEditor DMEEditor { get; set; }
        public IDMDataView DMDataView { get; set; }
        public string DataviewName { get; set; }
        public IApp Definition { get; set; }
        public DataViewDataSource DMDataViewDataSource { get; set; }
        public IEntityStructure CurrentEntity { get; set; } = null;
        public DataSet Data { get; set; }
        IDataSource ds;
        private bool CheckConnectionReady(string entityname)
        {
            if ( DMEEditor==null || DMDataView ==null)
            {
                return false;
            }
            if (DMDataViewDataSource == null)
            {
                DMDataViewDataSource = (DataViewDataSource)DMEEditor.GetDataSource(DataviewName);
                DMDataView = DMDataViewDataSource.DataView;
            }
            CurrentEntity = DMDataView.Entities[DMDataViewDataSource.EntityListIndex(entityname)];
            if(CurrentEntity == null)
            {
                DMEEditor.AddLogMessage("Beep", "Error Cannot get Entity from View", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed); ;
                return false;
            }
            ds = DMEEditor.GetDataSource(CurrentEntity.DataSourceID);
            if(ds == null)
            {
                DMEEditor.AddLogMessage("Beep", "Error Cannot get Entity from DataSource", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed); ;
                return false;
            }
            if (ds.ConnectionStatus != ConnectionState.Open)
            {
                DMEEditor.OpenDataSource(ds.DatasourceName);
                ds.ConnectionStatus = ds.Dataconnection.ConnectionStatus;
            }
            if (ds.ConnectionStatus != ConnectionState.Open)
            {
                DMEEditor.AddLogMessage("Beep", "Error Cannot get Open Entity Datasource Connection", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed); ;
                return false;
            }
                return true;
        }

        #region "Main Methods"
        public DataSet BuildDataSet()
        {

            Data = new DataSet();
            try
            {
                if (Definition == null)
                {
                    DMEEditor.AddLogMessage("Beep", $"Failed no Definition Defind", DateTime.Now, 0, null, Errors.Failed);
                    return null;
                }
                if (Definition.Entities == null)
                {
                    DMEEditor.AddLogMessage("Beep", $"Failed null Blocks", DateTime.Now, 0, null, Errors.Failed);
                    return null;
                }
                if (Definition.Entities.Count == 0)
                {
                    DMEEditor.AddLogMessage("Beep", $"Failed no Blocks", DateTime.Now, 0, null, Errors.Failed);
                    return null;
                }


                for (int i = 0; i < Definition.Entities.Where(p => p.EntityName != null).Count(); i++)
                {
                    DataTable tb = new DataTable(Definition.Entities[i].EntityName);
                    tb = DMEEditor.Utilfunction.ToDataTable(Definition.Entities[i]);
                    tb.TableName = Definition.Entities[i].EntityName;
                    Data.Tables.Add(tb);
                }
                CreateRelations();
                DMEEditor.AddLogMessage("Beep", $"Getting Data into DataSet", DateTime.Now, 0, null, Errors.Ok);
                return Data;
            }
            catch (Exception ex)
            {
                string errmsg = "Getting Data into DataSet";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                return null;
            }


        }
        #endregion
        #region "Table Events"
        private void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Table_TableCleared(object sender, DataTableClearEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Table_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region "Fill Methods"
        public void AddDataEntity(DataTable table)
        {
            Data.Tables.Add(table);
            table.RowChanged += Table_RowChanged;
            table.RowDeleted += Table_RowDeleted;
            table.TableNewRow += Table_TableNewRow;
            table.TableCleared += Table_TableCleared;
            table.ColumnChanged += Table_ColumnChanged;
        }
        public async Task<object> GetEntityDataAsync(string entityname, List<AppFilter> filters)
        {
            if (CheckConnectionReady(entityname))
            {

                return await DMDataViewDataSource.GetEntityAsync(entityname, filters);

            }
            else
                return null;
        }
        public async Task<DataTable> GetEntitiesAsync(string entityname, List<AppFilter> filters)
        {
            DataTable dt = null;

            if (CheckConnectionReady(entityname))
            {

                object retval = await GetEntityDataAsync(entityname, filters);
                Type tp = retval.GetType();
                if (tp.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IList)))
                {
                    dt = DMEEditor.Utilfunction.ToDataTable((IList)retval, DMEEditor.Utilfunction.GetListType(tp));
                }
                else
                {
                    dt = (DataTable)retval;

                }
            }
            return dt;
        }
        private List<DataTable> GetChildEntities(string entityname, List<AppFilter> filters)
        {
            List<DataTable> entitiesobjects = new List<DataTable>();
            foreach (IEntityStructure ent in DMDataView.Entities.Where(p => p.ParentId == CurrentEntity.Id))
            {
                DataTable dt;
                object retval = GetEntitiesAsync(entityname, filters);
                Type tp = retval.GetType();
                if (tp.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IList)))
                {
                    dt = DMEEditor.Utilfunction.ToDataTable((IList)retval, DMEEditor.Utilfunction.GetListType(tp));
                }
                else
                {
                    dt = (DataTable)retval;

                }
                entitiesobjects.Add(dt);
            }

            return entitiesobjects;
        }
      
        #endregion
        #region "Misc methods"
        private void GetFields(dynamic retval, IDataSource ds, string EntityName, EntityStructure entityStructure)
        {
            Type tp = retval.GetType();
            DataTable dt;
            if (entityStructure.Fields.Count == 0)
            {
                if (tp.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IList)))
                {
                    dt = DMEEditor.Utilfunction.ToDataTable((IList)retval, DMEEditor.Utilfunction.GetListType(tp));
                }
                else
                {
                    dt = (DataTable)retval;

                }
                //foreach (DataColumn item in dt.Columns)
                //{
                //    EntityField x = new EntityField();
                //    try
                //    {

                //        x.fieldname = item.ColumnName;
                //        x.fieldtype = item.DataType.ToString(); //"ColumnSize"
                //        x.Size1 = item.MaxLength;
                //        try
                //        {
                //            x.IsAutoIncrement = item.AutoIncrement;
                //        }
                //        catch (Exception)
                //        {

                //        }
                //        try
                //        {
                //            x.AllowDBNull = item.AllowDBNull;
                //        }
                //        catch (Exception)
                //        {


                //        }



                //        try
                //        {
                //            x.IsUnique = item.Unique;
                //        }
                //        catch (Exception)
                //        {

                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        DMEEditor.AddLogMessage("Error", $"{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                //    }

                //    if (x.IsKey)
                //    {
                //        entityStructure.PrimaryKeys.Add(x);
                //    }


                //    entityStructure.Fields.Add(x);
                //}




            }
            ds.Entities[ds.Entities.FindIndex(p => p.EntityName == entityStructure.EntityName)] = entityStructure;
            DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new DatasourceEntities { datasourcename = entityStructure.DataSourceID, Entities = ds.Entities });
        }
        private void CreateConstraint(DataSet dataSet, string childtable, string parenttable, string childcol, string parentcol)
        {
            // Declare parent column and child column variables.
            DataColumn parentColumn = new DataColumn();
            DataColumn childColumn = new DataColumn();
            ForeignKeyConstraint foreignKeyConstraint;
            if (dataSet.Tables.Contains(parenttable))
            {
                if (parenttable != childtable)
                {
                    parentColumn = dataSet.Tables[parenttable].Columns[parentcol];
                    childColumn = dataSet.Tables[childtable].Columns[childcol];
                    if (parentColumn != null && childColumn != null)
                    {
                        DataRelation relation=new DataRelation(parenttable + "_" + childtable,parentColumn,childColumn);
                        dataSet.Relations.Add(relation);
                        foreignKeyConstraint = new ForeignKeyConstraint(parenttable + "_" + parentcol, parentColumn, childColumn);

                        // Set null values when a value is deleted.
                        foreignKeyConstraint.DeleteRule = Rule.SetNull;
                        foreignKeyConstraint.UpdateRule = Rule.Cascade;
                        foreignKeyConstraint.AcceptRejectRule = AcceptRejectRule.None;

                        // Add the constraint, and set EnforceConstraints to true.
                        dataSet.Tables[childtable].Constraints.Add(foreignKeyConstraint);
                    }
                }



            }
            // Set parent and child column variables.

            // dataSet.EnforceConstraints = true;
        }
        private void CreateRelations()
        {

            foreach (IEntityStructure ent in DMDataView.Entities.Where(p => p.ParentId == CurrentEntity.Id))
            {
                if (CheckConnectionReady(ent.EntityName))
                {
                    if (ent.Relations != null)
                    {
                        if (ent.Relations.Count > 0)
                        {
                            foreach (RelationShipKeys relkey in ent.Relations.Where(o => o.RelatedEntityID != null).ToList())
                            {

                                CreateConstraint(Data, ent.DatasourceEntityName, relkey.RelatedEntityID, relkey.EntityColumnID, relkey.RelatedEntityColumnID);
                            }
                        }
                    }
                }


            }
        }
        #endregion
    }
}
