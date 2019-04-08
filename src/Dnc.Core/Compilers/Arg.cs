using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Compilers
{
    public class Arg<T1>
    {
        public T1 Arg1 { get; set; }
    }
    public class Arg<T1,T2>
    {
        public T1 Arg1 { get; set; }
        public T2 Arg2 { get; set; }
    }
    public class Arg<T1, T2,T3>
    {
        public T1 Arg1 { get; set; }
        public T2 Arg2 { get; set; }
        public T3 Arg3 { get; set; }
    }

    public class Arg<T1, T2, T3,T4>
    {
        public T1 Arg1 { get; set; }
        public T2 Arg2 { get; set; }
        public T3 Arg3 { get; set; }
        public T4 Arg4 { get; set; }
    }

    public class Arg<T1, T2, T3, T4,T5>
    {
        public T1 Arg1 { get; set; }
        public T2 Arg2 { get; set; }
        public T3 Arg3 { get; set; }
        public T4 Arg4 { get; set; }
        public T5 Arg5 { get; set; }
    }

    public class Arg<T1, T2, T3, T4, T5, T6>
    {
        public T1 Arg1 { get; set; }
        public T2 Arg2 { get; set; }
        public T3 Arg3 { get; set; }
        public T4 Arg4 { get; set; }
        public T5 Arg5 { get; set; }
        public T5 Arg6 { get; set; }
    }

    public class Arg<T1, T2, T3, T4, T5, T6,T7>
    {
        public T1 Arg1 { get; set; }
        public T2 Arg2 { get; set; }
        public T3 Arg3 { get; set; }
        public T4 Arg4 { get; set; }
        public T5 Arg5 { get; set; }
        public T6 Arg6 { get; set; }
        public T7 Arg7 { get; set; }
    }
}
