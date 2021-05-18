using System;
using System.Threading.Tasks;

namespace Kkommon
{
    /// <summary>
    ///     A class containing methods to quickly wrap <see cref="Action"/>s in try-catch-bocks for prototyping.
    /// </summary>
    public readonly struct Try
    {
        private readonly Result<object, Exception> _result;

        private Try(Exception exception) => _result = new Result<object, Exception>.Error(exception);
        private Try(object dummyObject) => _result = new Result<object, Exception>.Success(dummyObject);

        /// <summary>
        ///     Unwraps this <see cref="Try"/> into a <see cref="Result{TSuccess, TError}.Success"/> or throws if it
        ///     contains an <see cref="Result{TSuccess, TError}.Error"/>.
        /// </summary>
        /// <param name="errorMessage">The message to return if unwrapping was unsuccessful.</param>
        /// <returns>
        ///     The unwrapped <see cref="Result{TSuccess, TError}.Success"/>.
        /// </returns>
        public Result<object, Exception>.Success ExpectSuccess(string errorMessage)
            => _result as Result<object, Exception>.Success ?? throw new UnwrapException(errorMessage);

        /// <summary>
        ///     Unwraps this <see cref="Try"/> into a <see cref="Result{TSuccess, TError}.Error"/> or throws if it
        ///     contains a <see cref="Result{TSuccess, TError}.Success"/>.
        /// </summary>
        /// <param name="errorMessage">The message to return if unwrapping was unsuccessful.</param>
        /// <returns>
        ///     The unwrapped <see cref="Result{TSuccess, TError}.Error"/>.
        /// </returns>
        public Result<object, Exception>.Error ExpectError(string errorMessage)
            => _result as Result<object, Exception>.Error ?? throw new UnwrapException(errorMessage);

        /// <summary>
        ///     Matches the underlying type and executes the appropriate <see cref="Delegate"/>.
        /// </summary>
        /// <param name="successFunction">
        ///     The <see cref="Delegate"/> to execute if this <see cref="Try"/> contains a
        ///     <see cref="Result{TSuccess, TError}.Success"/>.
        /// </param>
        /// <param name="errorFunction">
        ///     The <see cref="Delegate"/> to execute if this <see cref="Try"/> contains a
        ///     <see cref="Result{TSuccess, TError}.Error"/>.
        /// </param>
        /// <typeparam name="T">The type of match-delegate return values.</typeparam>
        /// <returns>
        ///     The value returned by the executed match-<see cref="Delegate"/>.
        /// </returns>
        public T Match<T>(
            Func<Result<object, Exception>, T> successFunction,
            Func<Result<object, Exception>, T> errorFunction
        ) => _result switch
        {
            Result<object, Exception>.Success success => successFunction(success),
            Result<object, Exception>.Error error => errorFunction(error),
        };

        /// <summary>
        ///     Logs the result to standard output with an optional formatting <see cref="Delegate"/> and passes the
        ///     <see cref="Try"/> through.
        /// </summary>
        /// <returns>
        ///     This <see cref="Try"/>.
        /// </returns>
        public Try Log(Func<Result<object, Exception>, string>? logFormatter = null)
        {
            Console.WriteLine(logFormatter?.Invoke(_result) ?? ToString());
            return this;
        }

        /// <summary>
        ///     Accepts a logging <see cref="Delegate"/> to log the try result and passes the <see cref="Try"/> through.
        /// </summary>
        /// <returns>
        ///     This <see cref="Try"/>.
        /// </returns>
        public Try Log(Action<Result<object, Exception>> logger)
        {
            Preconditions.NotNull(logger, nameof(logger));

            logger(_result);
            return this;
        }

        /// <summary>
        ///     Accepts an async logging <see cref="Delegate"/> to log the try result and passes the <see cref="Try"/>
        ///     through.
        /// </summary>
        /// <remarks>
        ///     The Task is dispatched and not awaited.
        /// </remarks>
        /// <returns>
        ///     This <see cref="Try"/>.
        /// </returns>
        public Try Log(AsyncAction<Result<object, Exception>> asyncLogger)
        {
            Preconditions.NotNull(asyncLogger, nameof(asyncLogger));

            _ = asyncLogger(_result);
            return this;
        }

        /// <inheritdoc />
        public override string ToString() => _result is Result<object, Exception>.Error error
            ? error.Value.ToString()
            : "Try.Success";

        /// <summary>
        ///     Executes a given <see cref="Action"/>.
        /// </summary>
        /// <param name="action">The action to try.</param>
        /// <returns>
        ///     A <see cref="Try"/> representing the operation.
        /// </returns>
        public static Try Do(Action action)
        {
            try
            {
                action();

                return new Try((object) null!);
            }
            catch (Exception ex)
            {
                return new Try(ex);
            }
        }

        /// <summary>
        ///     Awaits a given <see cref="AsyncAction"/>.
        /// </summary>
        /// <param name="action">The async action to try.</param>
        /// <returns>
        ///     A <see cref="Task{T}"/> representing the asynchronous operation.
        /// </returns>
        public static async Task<Try> Await(AsyncAction action)
        {
            try
            {
                await action();

                return new Try((object) null!);
            }
            catch (Exception ex)
            {
                return new Try(ex);
            }
        }

        public static implicit operator Try(Exception exception) => new Try(exception);
    }

    /// <summary>
    ///     A class containing methods to quickly wrap <see cref="Func{T}"/>s in try-catch-bocks for prototyping.
    /// </summary>
    public readonly struct Try<TResult>
    {
        private readonly Result<TResult, Exception> _result;

        private Try(Exception exception) => _result = new Result<TResult, Exception>.Error(exception);
        private Try(TResult dummyObject) => _result = new Result<TResult, Exception>.Success(dummyObject);

        /// <summary>
        ///     Directly unwraps the value of the underlying <see cref="Result{TSuccess, TError}.Success"/> or throws
        ///     if it is an <see cref="Result{TSuccess, TError}.Error"/>.
        /// </summary>
        /// <returns>
        ///     The unwrapped <see cref="Result{TSuccess, TError}.Success.Value"/>.
        /// </returns>
        public TResult Unwrap() => _result is Result<TResult, Exception>.Success success
            ? success.Value
            : throw new UnwrapException("The underlying result was not a success");

        /// <summary>
        ///     Unwraps this <see cref="Try{TResult}"/> into a <see cref="Result{TSuccess, TError}.Success"/> or throws
        ///     if it is an <see cref="Result{TSuccess, TError}.Error"/>.
        /// </summary>
        /// <param name="errorMessage">The message to return if unwrapping was unsuccessful.</param>
        /// <returns>
        ///     The unwrapped <see cref="Result{TSuccess, TError}.Success"/>.
        /// </returns>
        public Result<TResult, Exception>.Success ExpectSuccess(string errorMessage)
            => _result as Result<TResult, Exception>.Success ?? throw new UnwrapException(errorMessage);

        /// <summary>
        ///     Unwraps this <see cref="Try{TResult}"/> into a <see cref="Result{TSuccess, TError}.Error"/> or throws
        ///     if it is an <see cref="Result{TSuccess, TError}.Success"/>.
        /// </summary>
        /// <param name="errorMessage">The message to return if unwrapping was unsuccessful.</param>
        /// <returns>
        ///     The unwrapped <see cref="Result{TSuccess, TError}.Error"/>.
        /// </returns>
        public Result<TResult, Exception>.Error ExpectError(string errorMessage)
            => _result as Result<TResult, Exception>.Error ?? throw new UnwrapException(errorMessage);

        /// <summary>
        ///     Matches the underlying type and executes the appropriate <see cref="Delegate"/>.
        /// </summary>
        /// <param name="successFunction">
        ///     The <see cref="Delegate"/> to execute if this <see cref="Try{TResult}"/> contains a
        ///     <see cref="Result{TSuccess, TError}.Success"/>.
        /// </param>
        /// <param name="errorFunction">
        ///     The <see cref="Delegate"/> to execute if this <see cref="Try{TResult}"/> contains a
        ///     <see cref="Result{TSuccess, TError}.Error"/>.
        /// </param>
        /// <typeparam name="T">The type of match-delegate return values.</typeparam>
        /// <returns>
        ///     The value returned by the executed match-<see cref="Delegate"/>.
        /// </returns>
        public T Match<T>(
            Func<Result<TResult, Exception>.Success, T> successFunction,
            Func<Result<TResult, Exception>.Error, T> errorFunction
        ) => _result switch
        {
            Result<TResult, Exception>.Success success => successFunction(success),
            Result<TResult, Exception>.Error error => errorFunction(error),
        };

        /// <summary>
        ///     Logs the result to standard output with an optional formatting <see cref="Delegate"/> and passes the
        ///     <see cref="Try{TResult}"/> through.
        /// </summary>
        /// <returns>
        ///     This <see cref="Try{TResult}"/>.
        /// </returns>
        public Try<TResult> Log(Func<Result<TResult, Exception>, string>? logFormatter = null)
        {
            Console.WriteLine(logFormatter?.Invoke(_result) ?? ToString());
            return this;
        }

        /// <summary>
        ///     Accepts a logging <see cref="Delegate"/> to log the try result and passes the <see cref="Try{TResult}"/>
        ///     through.
        /// </summary>
        /// <returns>
        ///     This <see cref="Try{TResult}"/>.
        /// </returns>
        public Try<TResult> Log(Action<Result<TResult, Exception>> logger)
        {
            Preconditions.NotNull(logger, nameof(logger));

            logger.Invoke(_result);
            return this;
        }

        /// <summary>
        ///     Accepts an async logging <see cref="Delegate"/> to log the try result and passes the
        ///     <see cref="Try{TResult}"/> through.
        /// </summary>
        /// <remarks>
        ///     The Task is dispatched and not awaited.
        /// </remarks>
        /// <returns>
        ///     This <see cref="Try{TResult}"/>.
        /// </returns>
        public Try<TResult> Log(AsyncAction<Result<TResult, Exception>> asyncLogger)
        {
            Preconditions.NotNull(asyncLogger, nameof(asyncLogger));

            _ = asyncLogger.Invoke(_result);
            return this;
        }

        // TODO: write proper ToString
        /// <inheritdoc />
        public override string ToString() => _result is Result<TResult, Exception>.Error error
            ? error.Value.ToString()
            : "Try.Success: " + ((_result as Result<TResult, Exception>.Success)!.Value?.ToString() ?? "<null>");

        /// <summary>
        ///     Executes a given <see cref="Func{T}"/>.
        /// </summary>
        /// <param name="function">The function to try.</param>
        /// <returns>
        ///     A <see cref="Task{T}"/> representing the asynchronous operation.
        /// </returns>
        public static Try<TResult> Return(Func<TResult> function)
        {
            try
            {
                return new Try<TResult>(function());
            }
            catch (Exception ex)
            {
                return new Try<TResult>(ex);
            }
        }

        /// <summary>
        ///     Awaits a given <see cref="AsyncFunc{T}"/>.
        /// </summary>
        /// <param name="function">The function to try.</param>
        /// <returns>
        ///     A <see cref="Task{T}"/> representing the asynchronous operation.
        /// </returns>
        public static async Task<Try<TResult>> Await(AsyncFunc<TResult> function)
        {
            try
            {
                return new Try<TResult>(await function());
            }
            catch (Exception ex)
            {
                return new Try<TResult>(ex);
            }
        }

        public static implicit operator Try<TResult>(TResult result) => new Try<TResult>(result);
        public static implicit operator Try<TResult>(Exception exception) => new Try<TResult>(exception);
    }
}