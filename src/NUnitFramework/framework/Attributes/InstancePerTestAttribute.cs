using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Framework.Attributes
{

    /// <summary>
    /// Marks a test assembly or fixture for creation on each individual test case.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InstancePerTestCaseAttribute : PropertyAttribute, IApplyToContext
    {
        /// <summary>
        /// Construct a InstancePerTestCase.
        /// </summary>
        public InstancePerTestCaseAttribute() : base() {

            Properties.Set(PropertyNames.InstancePerTestCase, true);

        }

        #region IApplyToContext Interface

        /// <summary>
        /// Modify the context to be used for child tests
        /// </summary>
        /// <param name="context">The current TestExecutionContext</param>
        public void ApplyToContext(TestExecutionContext context)
        {
            // Don't reflect Self in the context, since it will be
            // used for descendant tests.
            context.InstancePerTestCase = true;
        }

        #endregion
    }

}
