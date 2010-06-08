﻿using System;
using System.Diagnostics;
using EDM.FoundationClasses.Persistence.Core.Exception;

namespace EDM.FoundationClasses.Persistence.Core
{
    /// <summary>
    /// Design By Contract Checks.
    /// 
    /// Each method generates an exception or
    /// a trace assertion statement if the contract is broken.
    /// </summary>
    /// <remarks>
    /// This example shows how to call the Require method.
    /// <code>
    /// public void Test(int x)
    /// {
    /// 	try
    /// 	{
    ///			Check.Require(x > 1, "x must be > 1");
    ///		}
    ///		catch (System.Exception ex)
    ///		{
    ///			Console.WriteLine(ex.ToString());
    ///		}
    ///	}
    /// </code>
    ///
    /// You can direct output to a Trace listener. For example, you could insert
    /// <code>
    /// Trace.Listeners.Clear();
    /// Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
    /// </code>
    /// 
    /// or direct output to a file or the Event Log.
    /// 
    /// (Note: For ASP.NET clients use the Listeners collection
    /// of the Debug, not the Trace, object and, for a Release build, only exception-handling
    /// is possible.)
    /// </remarks>
    /// 
    sealed class Check
    {
        #region Interface

        /// <summary>
        /// Precondition check - should run regardless of preprocessor directives.
        /// </summary>
        public static void Require(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new PreconditionException(message);
            }
            else
            {
                Trace.Assert(assertion, string.Concat("Precondition: ", message));
            }
        }

        /// <summary>
        /// Precondition check - should run regardless of preprocessor directives.
        /// </summary>
        public static void Require(bool assertion, string message, System.Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new PreconditionException(message, inner);
            }
            else
            {
                Trace.Assert(assertion, string.Concat( "Precondition: ", message));
            }
        }

        /// <summary>
        /// Precondition check - should run regardless of preprocessor directives.
        /// </summary>
        public static void Require(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new PreconditionException("Precondition failed.");
            }
            else
            {
                Trace.Assert(assertion, "Precondition failed.");
            }
        }

        /// <summary>
        /// Postcondition check.
        /// </summary>
        public static void Ensure(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new PostconditionException(message);
            }
            else
            {
                Trace.Assert(assertion, string.Concat("Postcondition: ", message));
            }
        }

        /// <summary>
        /// Postcondition check.
        /// </summary>
        public static void Ensure(bool assertion, string message, System.Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new PostconditionException(message, inner);
            }
            else
            {
                Trace.Assert(assertion, string.Concat("Postcondition: ", message));
            }
        }

        /// <summary>
        /// Postcondition check.
        /// </summary>
        public static void Ensure(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new PostconditionException("Postcondition failed.");
            }
            else
            {
                Trace.Assert(assertion, "Postcondition failed.");
            }
        }

        /// <summary>
        /// Invariant check.
        /// </summary>
        public static void Invariant(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new InvariantException(message);
            }
            else
            {
                Trace.Assert(assertion, string.Concat("Invariant: ", message));
            }
        }

        /// <summary>
        /// Invariant check.
        /// </summary>
        public static void Invariant(bool assertion, string message, System.Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new InvariantException(message, inner);
            }
            else
            {
                Trace.Assert(assertion, string.Concat("Invariant: ", message));
            }
        }

        /// <summary>
        /// Invariant check.
        /// </summary>
        public static void Invariant(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new InvariantException("Invariant failed.");
            }
            else
            {
                Trace.Assert(assertion, "Invariant failed.");
            }
        }

        /// <summary>
        /// Assertion check.
        /// </summary>
        public static void Assert(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new AssertionException(message);
            }
            else
            {
                Trace.Assert(assertion, string.Concat("Assertion: ", message));
            }
        }

        /// <summary>
        /// Assertion check.
        /// </summary>
        public static void Assert(bool assertion, string message, System.Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new AssertionException(message, inner);
            }
            else
            {
                Trace.Assert(assertion, string.Concat("Assertion: ", message));
            }
        }

        /// <summary>
        /// Assertion check.
        /// </summary>
        public static void Assert(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion) throw new AssertionException("Assertion failed.");
            }
            else
            {
                Trace.Assert(assertion, "Assertion failed.");
            }
        }

        /// <summary>
        /// Set this if you wish to use Trace Assert statements 
        /// instead of exception handling. 
        /// (The Check class uses exception handling by default.)
        /// </summary>
        public static bool UseAssertions
        {
            get
            {
                return useAssertions;
            }
            set
            {
                useAssertions = value;
            }
        }

        #endregion // Interface

        #region Implementation

        // No creation
        private Check() { }

        /// <summary>
        /// Is exception handling being used?
        /// </summary>
        private static bool UseExceptions
        {
            get
            {
                return !useAssertions;
            }
        }

        // Are trace assertion statements being used? 
        // Default is to use exception handling.
        private static bool useAssertions = false;

        #endregion // Implementation

    } // End Check

}
