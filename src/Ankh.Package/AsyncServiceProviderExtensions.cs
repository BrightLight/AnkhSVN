// $Id$
//
// Copyright 2019 The AnkhSVN Project
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
namespace Ankh.VSPackage
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// Convenions methods for <see cref="IAsyncServiceProvider"/> and <see cref="IAsyncServiceProvider2"/>.
    /// </summary>
    public static class AsyncServiceProviderExtensions
    {
        /// <summary>
        /// Retrieves an async service.
        /// </summary>
        /// <typeparam name="T">Service to get</typeparam>
        /// <param name="asyncServiceProvider">The <see cref="IAsyncServiceProvider2"/> instance on which <see cref="IAsyncServiceProvider2.GetServiceAsync(Type, bool)"/> will be called.</param> 
        /// <returns>A task representing the service retrieval whose result is the service, or null if the retrieval failed.</returns>
        public static async Task<T> GetServiceAsync<T>(this IAsyncServiceProvider asyncServiceProvider)
            where T : class
        {
            return await asyncServiceProvider.GetServiceAsync(typeof(T)) as T;
        }

        /// <summary>
        /// Retrieves an async services but allows the caller to hint that exceptions may not have to be swallowed. It does not guarantee exceptions will be thrown however for failure cases.
        /// </summary>
        /// <typeparam name="T">Service to get</typeparam>
        /// <param name="asyncServiceProvider">The <see cref="IAsyncServiceProvider2"/> instance on which <see cref="IAsyncServiceProvider2.GetServiceAsync(Type, bool)"/> will be called.</param> 
        /// <param name="swallowExceptions">When this parameter is true GetServiceAsync will swallow exceptions thrown during the GetServiceAsync call and return null. When this is false exceptions thrown during the get service call may be thrown out of the method. A setting of false does not guarantee exceptions will be thrown for all services failures, or all service types </param>
        /// <returns>A task representing the service retrieval whose result is the service, or null if the retrieval failed.</returns>
        public static async Task<T> GetServiceAsync<T>(this IAsyncServiceProvider2 asyncServiceProvider, bool swallowExceptions)
            where T : class
        {
            return await asyncServiceProvider.GetServiceAsync(typeof(T), swallowExceptions) as T;
        }
    }
}
