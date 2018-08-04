namespace DataBaseClass
{
    public class RepositoryBase
    {
        #region
        protected Connection objConnection;
        public RepositoryBase()
        {
            objConnection = new Connection();
        }
        #endregion
    }
}
