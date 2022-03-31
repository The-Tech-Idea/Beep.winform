using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTechIdea.Beep.ADODataProvider
{
    public class BeepDataAdapter : IDbDataAdapter
    {
        public IDMEEditor DMEEditor { get; set; }
        public IDbCommand SelectCommand { get ; set ; }
        public IDbCommand InsertCommand { get ; set ; }
        public IDbCommand UpdateCommand { get ; set ; }
        public IDbCommand DeleteCommand { get ; set ; }
        public MissingMappingAction MissingMappingAction { get ; set ; }
        public MissingSchemaAction MissingSchemaAction { get ; set ; }

        public ITableMappingCollection TableMappings { get; }

        public int Fill(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            switch (schemaType) 
            {
                case SchemaType.Mapped:
                    break;
                case SchemaType.Source:
                    break;
                
            
            }
        }

        public IDataParameter[] GetFillParameters()
        {
            throw new NotImplementedException();
        }

        public int Update(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
    }
}
