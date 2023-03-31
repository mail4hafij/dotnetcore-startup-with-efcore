/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore_startup_with_efcore
 */

using Common.Contract;

namespace Core.LIB
{
    public interface IHandlerCaller
    {
        TResp Process<TReq, TResp>(TReq req) where TResp : Resp, new() where TReq : Req, new();
    }
}
