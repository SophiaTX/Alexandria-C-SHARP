using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
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

    public class Data2
    {
        public string base58str { get; set; }
        public string @method { get; set; }
        public List<string> @params { get; set; }
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

    public class RootObject
    {
        public int id { get; set; }
        public Error error { get; set; }
    }
}