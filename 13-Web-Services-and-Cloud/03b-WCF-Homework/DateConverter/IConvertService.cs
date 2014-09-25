namespace DateConverter
{
    using System;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConvertService" in both code and config file together.

    [ServiceContract]
    public interface IConvertService
    {
        [OperationContract]
        string Convert(DateTime date);
    }
}
