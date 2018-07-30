using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    public class Context
{
    public string level { get; set; }
    public string file { get; set; }
    public int line { get; set; }
    public string method { get; set; }
    public string hostname { get; set; }
    public DateTime timestamp { get; set; }
}

public class Context2
{
    public string level { get; set; }
    public string file { get; set; }
    public int line { get; set; }
    public string method { get; set; }
    public string hostname { get; set; }
    public DateTime timestamp { get; set; }
}

public class Trx
{
    public int ref_block_num { get; set; }
    public object ref_block_prefix { get; set; }
    public DateTime expiration { get; set; }
    public List<List<object>> operations { get; set; }
    public List<object> extensions { get; set; }
    public List<string> signatures { get; set; }
}

public class Data5
{
    public List<object> op { get; set; }
    public string what { get; set; }
    public Trx trx { get; set; }
}

public class Stack2
{
    public Context2 context { get; set; }
    public string format { get; set; }
    public Data5 data { get; set; }
}

public class Data4
{
    public int code { get; set; }
    public string name { get; set; }
    public string message { get; set; }
    public List<Stack2> stack { get; set; }
}

public class Error2
{
    public int code { get; set; }
    public string message { get; set; }
    public Data4 data { get; set; }
}

public class Data3
{
    public int id { get; set; }
    public Error2 error { get; set; }
}

public class Tx
{
    public int ref_block_num { get; set; }
    public long ref_block_prefix { get; set; }
    public DateTime expiration { get; set; }
    public List<List<object>> operations { get; set; }
    public List<object> extensions { get; set; }
    public List<string> signatures { get; set; }
}

public class CallParam
{
    public int ref_block_num { get; set; }
    public long ref_block_prefix { get; set; }
    public DateTime expiration { get; set; }
    public List<List<object>> operations { get; set; }
    public List<object> extensions { get; set; }
    public List<string> signatures { get; set; }
}

public class Data2
{
    public string error { get; set; }
    public Data3 data { get; set; }
    public Tx tx { get; set; }
    public string invalidNameCallMethod { get; set; }
    public List<CallParam> invalidNameCallParams { get; set; }
}

public class Stack
{
    public Context context { get; set; }
    public string format { get; set; }
    public Data2 data { get; set; }
}

public class Data
{
    public int code { get; set; }
    public string name { get; set; }
    public string message { get; set; }
    public List<Stack> stack { get; set; }
}

public class Error
{
    public int code { get; set; }
    public string message { get; set; }
    public Data data { get; set; }
}

public class ErrorResponse
{
    public int id { get; set; }
    public Error error { get; set; }
}
}