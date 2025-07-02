using Microsoft.Data.SqlClient;

namespace Vexplora.Domain.Shared;

public class ExceptionSql
{
    public static bool IsForeignKeyViolation(Exception ex)
    {
        if (ex.InnerException is SqlException sqlEx)
        {
            return sqlEx.Number == 547; 
        }

        return false;
    }
}