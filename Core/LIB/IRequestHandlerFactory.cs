/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore_startup_with_efcore
 */

using Common.Contract;

namespace Core.LIB
{
    public interface IRequestHandlerFactory
    {
        RequestHandler<TReq, TResp> Create<TReq, TResp>() where TReq : Req, new() where TResp : Resp, new();
    }
}