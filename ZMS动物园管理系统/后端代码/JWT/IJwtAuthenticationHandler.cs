/*-----------------------------------------
 * 作者：杨泽华
 * 最后修改：2021.7.15
 * 功能：生成token的相应类
 ----------------------------------------*/
namespace BackEnd
{
    public interface IJwtAuthenticationHandler
    {
        string Authenticate(string username, string password, string type);
    }
}
