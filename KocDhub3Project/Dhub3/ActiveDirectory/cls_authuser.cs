
using System;
using System.Runtime.InteropServices; // DllImport
using System.Security.Principal; // WindowsImpersonationContext


namespace FinderData
{
    [Serializable()]
    public class clsAuthenticator
    {

        // group type enum
        public enum SECURITY_IMPERSONATION_LEVEL : int
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3
        }

        public enum LogonType : int
        {
            // This logon type is intended for users who will be interactively using the computer, such as a user being logged on
            // by a terminal server, remote shell, or similar process.
            // This logon type has the additional expense of caching logon information for disconnected operations;
            // therefore, it is inappropriate for some client/server applications,
            // such as a mail server.
            LOGON32_LOGON_INTERACTIVE = 2,

            // This logon type is intended for high performance servers to authenticate plaintext passwords.
            // The LogonUser function does not cache credentials for this logon type.
            LOGON32_LOGON_NETWORK = 3,

            // This logon type is intended for batch servers, where processes may be executing on behalf of a user without
            // their direct intervention. This type is also for higher performance servers that process many plaintext
            // authentication attempts at a time, such as mail or Web servers.
            // The LogonUser function does not cache credentials for this logon type.
            LOGON32_LOGON_BATCH = 4,

            // Indicates a service-type logon. The account provided must have the service privilege enabled.
            LOGON32_LOGON_SERVICE = 5,

            // This logon type is for GINA DLLs that log on users who will be interactively using the computer.
            // This logon type can generate a unique audit record that shows when the workstation was unlocked.
            LOGON32_LOGON_UNLOCK = 7,

            // This logon type preserves the name and password in the authentication package, which allows the server to make
            // connections to other network servers while impersonating the client. A server can accept plaintext credentials
            // from a client, call LogonUser, verify that the user can access the system across the network, and still
            // communicate with other servers.
            // NOTE: Windows NT:  This value is not supported.
            LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

            // This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
            // The new logon session has the same local identifier but uses different credentials for other network connections.
            // NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
            // NOTE: Windows NT:  This value is not supported.
            LOGON32_LOGON_NEW_CREDENTIALS = 9
        }

        public enum LogonProvider : int
        {
            // Use the standard logon provider for the system.
            // The default security provider is negotiate, unless you pass NULL for the domain name and the user name
            // is not in UPN format. In this case, the default provider is NTLM.
            // NOTE: Windows 2000/NT:   The default security provider is NTLM.
            LOGON32_PROVIDER_DEFAULT = 0,
            LOGON32_PROVIDER_WINNT35 = 1,
            LOGON32_PROVIDER_WINNT40 = 2,
            LOGON32_PROVIDER_WINNT50 = 3
        }

        // obtains user token
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, LogonType dwLogonType, LogonProvider dwLogonProvider, ref IntPtr phToken);


        // closes open handes returned by LogonUser
        [DllImport("kernel32.dll")]
        static extern bool CloseHandle(IntPtr handle);

        // creates duplicate token handle
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        static extern bool DuplicateToken(IntPtr ExistingTokenHandle, short SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

        // WindowsImpersonationContext newUser;
        private WindowsImpersonationContext newUser;


        // 
        // Attempts to impersonate a user.  If successful, returns 
        // a WindowsImpersonationContext of the new users identity.
        // 
        // Username you want to impersonate
        // Logon domain
        // User's password to logon with
        // 
        public void Impersonator(string sDomain, string sUsername, string sPassword)
        {
            // initialize tokens
            // IntPtr pExistingTokenHandle = new IntPtr(0);
            // IntPtr pDuplicateTokenHandle = new IntPtr(0);
            // pExistingTokenHandle = IntPtr.Zero;
            // pDuplicateTokenHandle = IntPtr.Zero;

            var pExistingTokenHandle = new IntPtr(0);
            var pDuplicateTokenHandle = new IntPtr(0);

            if (string.IsNullOrEmpty(sDomain))
            {
                sDomain = Environment.MachineName;
            }

            try
            {

                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

                int bImpersonated = clsAuthenticator.LogonUser( sUsername,  sDomain,  sPassword, (LogonType)LOGON32_LOGON_NEW_CREDENTIALS, (LogonProvider)LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);

                if (bImpersonated == 0)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    throw new ApplicationException("LogonUser() failed with error code: " + nErrorCode.ToString());
                }

                bool bRetVal = DuplicateToken(pExistingTokenHandle, (short)SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, ref pDuplicateTokenHandle);
                if (bRetVal == false)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    CloseHandle(pExistingTokenHandle);
                    throw new ApplicationException("DuplicateToken() failed with error code: " + nErrorCode);
                }
                else
                {
                    var newId = new WindowsIdentity(pDuplicateTokenHandle);
                    var impersonatedUser = newId.Impersonate();
                    newUser = impersonatedUser;
                }
            }

            catch (Exception ex)
            {
            }

            finally
            {
                if (pExistingTokenHandle != IntPtr.Zero)
                {
                    CloseHandle(pExistingTokenHandle);
                }
                if (pDuplicateTokenHandle != IntPtr.Zero)
                {
                    CloseHandle(pDuplicateTokenHandle);
                }
            }

        }

        public void Undo()
        {
            newUser.Undo();
        }
    }
}