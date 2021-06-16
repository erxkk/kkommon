using System;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Kkommon
{
    // Documentation omitted for obvious implementations
    [PublicAPI]
    public delegate Task AsyncEventHandler<in TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate();

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T>(T arg);

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2>(T1 arg1, T2 arg2);

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13, in T14>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13, in T14, in T15>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15
    );

    [PublicAPI]
    public delegate Task<bool> AsyncPredicate<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13, in T14, in T15, in T16>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15,
        T16 arg16
    );

    [PublicAPI]
    public delegate Task AsyncAction();

    [PublicAPI]
    public delegate Task AsyncAction<in T>(T arg);

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2>(T1 arg1, T2 arg2);

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11,
        in T12>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11,
        in T12, in T13, in T14>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11,
        in T12, in T13, in T14, in T15>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15
    );

    [PublicAPI]
    public delegate Task AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11,
        in T12, in T13, in T14, in T15, in T16>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15,
        T16 arg16
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<TResult>();

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T, TResult>(T arg);

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, TResult>(T1 arg1, T2 arg2);

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, TResult>(T1 arg1, T2 arg2, T3 arg3);

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13, in T14, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13, in T14, in T15, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15
    );

    [PublicAPI]
    public delegate Task<TResult> AsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10,
        in T11, in T12, in T13, in T14, in T15, in T16, TResult>(
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15,
        T16 arg16
    );
}