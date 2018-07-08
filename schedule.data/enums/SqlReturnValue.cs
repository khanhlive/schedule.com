namespace schedule.data.enums
{ 
    public class SqlReturnValue
    {

    }
    public enum SqlResultType
    {
        Existed = -1,
        NotExisted = -2,
        OK = 1,
        Failed = 0,
        Exception=2,
        None=3
    }
    public enum MessageObjectType
    {
        Info,
        Warning,
        Success,
        Error
    }
}
