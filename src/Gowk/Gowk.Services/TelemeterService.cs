//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Gowk.Services
{

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.3038.
// 


	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(Name = "TelemeterServiceSOAP", Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class TelemeterService : System.Web.Services.Protocols.SoapHttpClientProtocol
	{

		private System.Threading.SendOrPostCallback retrieveUsageOperationCompleted;

		private System.Threading.SendOrPostCallback retrievePossibleStagesOperationCompleted;

		/// <remarks/>
		public TelemeterService()
		{
			this.Url = "https://t4t.services.telenet.be/TelemeterService";
		}

		/// <remarks/>
		public event retrieveUsageCompletedEventHandler retrieveUsageCompleted;

		/// <remarks/>
		public event retrievePossibleStagesCompletedEventHandler retrievePossibleStagesCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.telenet.be/TelemeterService/retrieveUsage", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
		[return: System.Xml.Serialization.XmlElementAttribute("RetrieveUsageResponse", Namespace = "http://www.telenet.be/TelemeterService/")]
		public RetrieveUsageResponseType retrieveUsage([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.telenet.be/TelemeterService/")] RetrieveUsageRequestType RetrieveUsageRequest)
		{
			object[] results = this.Invoke("retrieveUsage", new object[] { RetrieveUsageRequest });
			return ((RetrieveUsageResponseType)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginretrieveUsage(RetrieveUsageRequestType RetrieveUsageRequest, System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("retrieveUsage", new object[] { RetrieveUsageRequest }, callback, asyncState);
		}

		/// <remarks/>
		public RetrieveUsageResponseType EndretrieveUsage(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((RetrieveUsageResponseType)(results[0]));
		}

		/// <remarks/>
		public void retrieveUsageAsync(RetrieveUsageRequestType RetrieveUsageRequest)
		{
			this.retrieveUsageAsync(RetrieveUsageRequest, null);
		}

		/// <remarks/>
		public void retrieveUsageAsync(RetrieveUsageRequestType RetrieveUsageRequest, object userState)
		{
			if ((this.retrieveUsageOperationCompleted == null))
			{
				this.retrieveUsageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnretrieveUsageOperationCompleted);
			}
			this.InvokeAsync("retrieveUsage", new object[] { RetrieveUsageRequest }, this.retrieveUsageOperationCompleted, userState);
		}

		private void OnretrieveUsageOperationCompleted(object arg)
		{
			if ((this.retrieveUsageCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.retrieveUsageCompleted(this, new retrieveUsageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.telenet.be/TelemeterService/retrievePossibleStages", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
		[return: System.Xml.Serialization.XmlElementAttribute("RetrievePossibleStagesResponse", Namespace = "http://www.telenet.be/TelemeterService/")]
		public RetrievePossibleStagesResponseType retrievePossibleStages([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.telenet.be/TelemeterService/")] RetrievePossibleStagesRequestType RetrievePossibleStagesRequest)
		{
			object[] results = this.Invoke("retrievePossibleStages", new object[] { RetrievePossibleStagesRequest });
			return ((RetrievePossibleStagesResponseType)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginretrievePossibleStages(RetrievePossibleStagesRequestType RetrievePossibleStagesRequest, System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("retrievePossibleStages", new object[] { RetrievePossibleStagesRequest }, callback, asyncState);
		}

		/// <remarks/>
		public RetrievePossibleStagesResponseType EndretrievePossibleStages(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((RetrievePossibleStagesResponseType)(results[0]));
		}

		/// <remarks/>
		public void retrievePossibleStagesAsync(RetrievePossibleStagesRequestType RetrievePossibleStagesRequest)
		{
			this.retrievePossibleStagesAsync(RetrievePossibleStagesRequest, null);
		}

		/// <remarks/>
		public void retrievePossibleStagesAsync(RetrievePossibleStagesRequestType RetrievePossibleStagesRequest, object userState)
		{
			if ((this.retrievePossibleStagesOperationCompleted == null))
			{
				this.retrievePossibleStagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnretrievePossibleStagesOperationCompleted);
			}
			this.InvokeAsync("retrievePossibleStages", new object[] { RetrievePossibleStagesRequest }, this.retrievePossibleStagesOperationCompleted, userState);
		}

		private void OnretrievePossibleStagesOperationCompleted(object arg)
		{
			if ((this.retrievePossibleStagesCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.retrievePossibleStagesCompleted(this, new retrievePossibleStagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		public new void CancelAsync(object userState)
		{
			base.CancelAsync(userState);
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class RetrieveUsageRequestType
	{

		private string userIdField;

		private string passwordField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string UserId
		{
			get { return this.userIdField; }
			set { this.userIdField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string Password
		{
			get { return this.passwordField; }
			set { this.passwordField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class RetrievePossibleStagesResponseType
	{

		private TicketType ticketField;

		private StageType[] stageListField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public TicketType Ticket
		{
			get { return this.ticketField; }
			set { this.ticketField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("Stage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
		public StageType[] StageList
		{
			get { return this.stageListField; }
			set { this.stageListField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class TicketType
	{

		private System.DateTime timestampField;

		private System.DateTime expiryTimestampField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public System.DateTime Timestamp
		{
			get { return this.timestampField; }
			set { this.timestampField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public System.DateTime ExpiryTimestamp
		{
			get { return this.expiryTimestampField; }
			set { this.expiryTimestampField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class StageType
	{

		private string stageNumberField;

		private RGBColorType colorField;

		private string descriptionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "positiveInteger")]
		public string StageNumber
		{
			get { return this.stageNumberField; }
			set { this.stageNumberField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RGBColorType Color
		{
			get { return this.colorField; }
			set { this.colorField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string Description
		{
			get { return this.descriptionField; }
			set { this.descriptionField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class RGBColorType
	{

		private string redField;

		private string greenField;

		private string blueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "nonNegativeInteger")]
		public string Red
		{
			get { return this.redField; }
			set { this.redField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "nonNegativeInteger")]
		public string Green
		{
			get { return this.greenField; }
			set { this.greenField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "nonNegativeInteger")]
		public string Blue
		{
			get { return this.blueField; }
			set { this.blueField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class RetrievePossibleStagesRequestType
	{

		private string userIdField;

		private string passwordField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string UserId
		{
			get { return this.userIdField; }
			set { this.userIdField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string Password
		{
			get { return this.passwordField; }
			set { this.passwordField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class DailyUsageType
	{

		private System.DateTime dayField;

		private string usageField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
		public System.DateTime Day
		{
			get { return this.dayField; }
			set { this.dayField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "nonNegativeInteger")]
		public string Usage
		{
			get { return this.usageField; }
			set { this.usageField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class VolumeType
	{

		private UnitType unitField;

		private string limitField;

		private string totalUsageField;

		private DailyUsageType[] dailyUsageListField;

		public VolumeType()
		{
			this.unitField = UnitType.MB;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public UnitType Unit
		{
			get { return this.unitField; }
			set { this.unitField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "nonNegativeInteger")]
		public string Limit
		{
			get { return this.limitField; }
			set { this.limitField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "nonNegativeInteger")]
		public string TotalUsage
		{
			get { return this.totalUsageField; }
			set { this.totalUsageField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("DailyUsage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
		public DailyUsageType[] DailyUsageList
		{
			get { return this.dailyUsageListField; }
			set { this.dailyUsageListField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public enum UnitType
	{

		/// <remarks/>
		MB,

		/// <remarks/>
		GB
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.telenet.be/TelemeterService/")]
	public partial class RetrieveUsageResponseType
	{

		private TicketType ticketField;

		private object itemField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public TicketType Ticket
		{
			get { return this.ticketField; }
			set { this.ticketField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Stage", typeof(StageType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlElementAttribute("Volume", typeof(VolumeType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public object Item
		{
			get { return this.itemField; }
			set { this.itemField = value; }
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	public delegate void retrieveUsageCompletedEventHandler(object sender, retrieveUsageCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class retrieveUsageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal retrieveUsageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public RetrieveUsageResponseType Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((RetrieveUsageResponseType)(this.results[0]));
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	public delegate void retrievePossibleStagesCompletedEventHandler(object sender, retrievePossibleStagesCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class retrievePossibleStagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal retrievePossibleStagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public RetrievePossibleStagesResponseType Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((RetrievePossibleStagesResponseType)(this.results[0]));
			}
		}
	}
}
