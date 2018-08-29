using System;
using System.Fabric;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

using Microsoft.ServiceFabric.Services.Communication.Wcf.Runtime;

namespace Microsoft.ServiceFabric.Services.Communication.Wcf.Web.Runtime
{

    /// <summary>
    /// A Windows Communication Foundation based listener for Service Fabric based stateless or stateful service
    /// using the <see cref="WebServiceHost"/>.
    /// </summary>
    /// <typeparam name="TServiceContract">Type of the WCF service contract.</typeparam>
    public class WcfWebCommunicationListener<TServiceContract> :
        WcfCommunicationListener<TServiceContract>
    {


        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceContext"></param>
        /// <param name="wcfServiceObject"></param>
        public WcfWebCommunicationListener(
            ServiceContext serviceContext,
            TServiceContract wcfServiceObject) :
            base(serviceContext, wcfServiceObject)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceContext"></param>
        /// <param name="wcfServiceObject"></param>
        /// <param name="listenerBinding"></param>
        /// <param name="endpointResourceName"></param>
        public WcfWebCommunicationListener(
            ServiceContext serviceContext,
            TServiceContract wcfServiceObject,
            Binding listenerBinding = null,
            string endpointResourceName = null) :
            base(serviceContext, wcfServiceObject, listenerBinding, endpointResourceName)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceContext"></param>
        /// <param name="wcfServiceType"></param>
        /// <param name="listenerBinding"></param>
        /// <param name="endpointResourceName"></param>
        public WcfWebCommunicationListener(
            ServiceContext serviceContext,
            Type wcfServiceType,
            Binding listenerBinding = null,
            string endpointResourceName = null) :
            base(serviceContext, wcfServiceType, listenerBinding, endpointResourceName)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceContext"></param>
        /// <param name="wcfServiceObject"></param>
        /// <param name="listenerBinding"></param>
        /// <param name="address"></param>
        public WcfWebCommunicationListener(
            ServiceContext serviceContext,
            TServiceContract wcfServiceObject,
            Binding listenerBinding = null,
            EndpointAddress address = null) :
            base(serviceContext, wcfServiceObject, listenerBinding, address)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceContext"></param>
        /// <param name="wcfServiceType"></param>
        /// <param name="listenerBinding"></param>
        /// <param name="address"></param>
        public WcfWebCommunicationListener(
            ServiceContext serviceContext,
            Type wcfServiceType,
            Binding listenerBinding = null,
            EndpointAddress address = null) :
            base(serviceContext, wcfServiceType, listenerBinding, address)
        {

        }

        /// <summary>
        /// Gets the <see cref="WebServiceHost"/> used by this listener to host the WCF service implementation.
        /// </summary>
        public new WebServiceHost ServiceHost => (WebServiceHost)base.ServiceHost;

        /// <summary>
        /// Creates a new <see cref="WebServiceHost"/> instance.
        /// </summary>
        /// <param name="wcfServiceObject"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        protected override ServiceHost CreateServiceHost(
           object wcfServiceObject,
           ServiceEndpoint endpoint)
        {
            return this.ConfigureHost(new WebServiceHost(wcfServiceObject), endpoint, true);
        }

        /// <summary>
        /// Creates a new <see cref="WebServiceHost"/> instance.
        /// </summary>
        /// <param name="wcfServiceType"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        protected override ServiceHost CreateServiceHost(
           Type wcfServiceType,
           ServiceEndpoint endpoint)
        {
            return this.ConfigureHost(new WebServiceHost(wcfServiceType), endpoint, false);
        }

    }

}
