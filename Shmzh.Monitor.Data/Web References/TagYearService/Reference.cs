﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18444 版自动生成。
// 
#pragma warning disable 1591

namespace Shmzh.Monitor.Data.TagYearService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TagYearSoap", Namespace="http://service.ypwater.com/")]
    public partial class TagYear : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Get_By_TagId_CycleIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback Get_By_TagId_DateTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback Get_By_TagIds_CycleIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback Get_By_TagIds_DateTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback Get_Latest_By_TagIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback Get_Latest_By_TagIdsOperationCompleted;
        
        private System.Threading.SendOrPostCallback Get_Latest_AllOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TagYear() {
            this.Url = global::Shmzh.Monitor.Data.Properties.Settings.Default.Shmzh_Monitor_Data_TagYearService_TagYear;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event Get_By_TagId_CycleIdCompletedEventHandler Get_By_TagId_CycleIdCompleted;
        
        /// <remarks/>
        public event Get_By_TagId_DateTimeCompletedEventHandler Get_By_TagId_DateTimeCompleted;
        
        /// <remarks/>
        public event Get_By_TagIds_CycleIdCompletedEventHandler Get_By_TagIds_CycleIdCompleted;
        
        /// <remarks/>
        public event Get_By_TagIds_DateTimeCompletedEventHandler Get_By_TagIds_DateTimeCompleted;
        
        /// <remarks/>
        public event Get_Latest_By_TagIdCompletedEventHandler Get_Latest_By_TagIdCompleted;
        
        /// <remarks/>
        public event Get_Latest_By_TagIdsCompletedEventHandler Get_Latest_By_TagIdsCompleted;
        
        /// <remarks/>
        public event Get_Latest_AllCompletedEventHandler Get_Latest_AllCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.ypwater.com/Get_By_TagId_CycleId", RequestNamespace="http://service.ypwater.com/", ResponseNamespace="http://service.ypwater.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TagYearInfo[] Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId) {
            object[] results = this.Invoke("Get_By_TagId_CycleId", new object[] {
                        tagId,
                        beginCycleId,
                        endCycleId});
            return ((TagYearInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void Get_By_TagId_CycleIdAsync(string tagId, int beginCycleId, int endCycleId) {
            this.Get_By_TagId_CycleIdAsync(tagId, beginCycleId, endCycleId, null);
        }
        
        /// <remarks/>
        public void Get_By_TagId_CycleIdAsync(string tagId, int beginCycleId, int endCycleId, object userState) {
            if ((this.Get_By_TagId_CycleIdOperationCompleted == null)) {
                this.Get_By_TagId_CycleIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_By_TagId_CycleIdOperationCompleted);
            }
            this.InvokeAsync("Get_By_TagId_CycleId", new object[] {
                        tagId,
                        beginCycleId,
                        endCycleId}, this.Get_By_TagId_CycleIdOperationCompleted, userState);
        }
        
        private void OnGet_By_TagId_CycleIdOperationCompleted(object arg) {
            if ((this.Get_By_TagId_CycleIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_By_TagId_CycleIdCompleted(this, new Get_By_TagId_CycleIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.ypwater.com/Get_By_TagId_DateTime", RequestNamespace="http://service.ypwater.com/", ResponseNamespace="http://service.ypwater.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TagYearInfo[] Get_By_TagId_DateTime(string tagId, System.DateTime beginTime, System.DateTime endTime) {
            object[] results = this.Invoke("Get_By_TagId_DateTime", new object[] {
                        tagId,
                        beginTime,
                        endTime});
            return ((TagYearInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void Get_By_TagId_DateTimeAsync(string tagId, System.DateTime beginTime, System.DateTime endTime) {
            this.Get_By_TagId_DateTimeAsync(tagId, beginTime, endTime, null);
        }
        
        /// <remarks/>
        public void Get_By_TagId_DateTimeAsync(string tagId, System.DateTime beginTime, System.DateTime endTime, object userState) {
            if ((this.Get_By_TagId_DateTimeOperationCompleted == null)) {
                this.Get_By_TagId_DateTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_By_TagId_DateTimeOperationCompleted);
            }
            this.InvokeAsync("Get_By_TagId_DateTime", new object[] {
                        tagId,
                        beginTime,
                        endTime}, this.Get_By_TagId_DateTimeOperationCompleted, userState);
        }
        
        private void OnGet_By_TagId_DateTimeOperationCompleted(object arg) {
            if ((this.Get_By_TagId_DateTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_By_TagId_DateTimeCompleted(this, new Get_By_TagId_DateTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.ypwater.com/Get_By_TagIds_CycleId", RequestNamespace="http://service.ypwater.com/", ResponseNamespace="http://service.ypwater.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TagYearInfo[] Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId) {
            object[] results = this.Invoke("Get_By_TagIds_CycleId", new object[] {
                        tagIds,
                        beginCycleId,
                        endCycleId});
            return ((TagYearInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void Get_By_TagIds_CycleIdAsync(string tagIds, int beginCycleId, int endCycleId) {
            this.Get_By_TagIds_CycleIdAsync(tagIds, beginCycleId, endCycleId, null);
        }
        
        /// <remarks/>
        public void Get_By_TagIds_CycleIdAsync(string tagIds, int beginCycleId, int endCycleId, object userState) {
            if ((this.Get_By_TagIds_CycleIdOperationCompleted == null)) {
                this.Get_By_TagIds_CycleIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_By_TagIds_CycleIdOperationCompleted);
            }
            this.InvokeAsync("Get_By_TagIds_CycleId", new object[] {
                        tagIds,
                        beginCycleId,
                        endCycleId}, this.Get_By_TagIds_CycleIdOperationCompleted, userState);
        }
        
        private void OnGet_By_TagIds_CycleIdOperationCompleted(object arg) {
            if ((this.Get_By_TagIds_CycleIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_By_TagIds_CycleIdCompleted(this, new Get_By_TagIds_CycleIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.ypwater.com/Get_By_TagIds_DateTime", RequestNamespace="http://service.ypwater.com/", ResponseNamespace="http://service.ypwater.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TagYearInfo[] Get_By_TagIds_DateTime(string tagIds, System.DateTime beginTime, System.DateTime endTime) {
            object[] results = this.Invoke("Get_By_TagIds_DateTime", new object[] {
                        tagIds,
                        beginTime,
                        endTime});
            return ((TagYearInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void Get_By_TagIds_DateTimeAsync(string tagIds, System.DateTime beginTime, System.DateTime endTime) {
            this.Get_By_TagIds_DateTimeAsync(tagIds, beginTime, endTime, null);
        }
        
        /// <remarks/>
        public void Get_By_TagIds_DateTimeAsync(string tagIds, System.DateTime beginTime, System.DateTime endTime, object userState) {
            if ((this.Get_By_TagIds_DateTimeOperationCompleted == null)) {
                this.Get_By_TagIds_DateTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_By_TagIds_DateTimeOperationCompleted);
            }
            this.InvokeAsync("Get_By_TagIds_DateTime", new object[] {
                        tagIds,
                        beginTime,
                        endTime}, this.Get_By_TagIds_DateTimeOperationCompleted, userState);
        }
        
        private void OnGet_By_TagIds_DateTimeOperationCompleted(object arg) {
            if ((this.Get_By_TagIds_DateTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_By_TagIds_DateTimeCompleted(this, new Get_By_TagIds_DateTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.ypwater.com/Get_Latest_By_TagId", RequestNamespace="http://service.ypwater.com/", ResponseNamespace="http://service.ypwater.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TagYearInfo Get_Latest_By_TagId(string tagId) {
            object[] results = this.Invoke("Get_Latest_By_TagId", new object[] {
                        tagId});
            return ((TagYearInfo)(results[0]));
        }
        
        /// <remarks/>
        public void Get_Latest_By_TagIdAsync(string tagId) {
            this.Get_Latest_By_TagIdAsync(tagId, null);
        }
        
        /// <remarks/>
        public void Get_Latest_By_TagIdAsync(string tagId, object userState) {
            if ((this.Get_Latest_By_TagIdOperationCompleted == null)) {
                this.Get_Latest_By_TagIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_Latest_By_TagIdOperationCompleted);
            }
            this.InvokeAsync("Get_Latest_By_TagId", new object[] {
                        tagId}, this.Get_Latest_By_TagIdOperationCompleted, userState);
        }
        
        private void OnGet_Latest_By_TagIdOperationCompleted(object arg) {
            if ((this.Get_Latest_By_TagIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_Latest_By_TagIdCompleted(this, new Get_Latest_By_TagIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.ypwater.com/Get_Latest_By_TagIds", RequestNamespace="http://service.ypwater.com/", ResponseNamespace="http://service.ypwater.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TagYearInfo[] Get_Latest_By_TagIds(string tagIds) {
            object[] results = this.Invoke("Get_Latest_By_TagIds", new object[] {
                        tagIds});
            return ((TagYearInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void Get_Latest_By_TagIdsAsync(string tagIds) {
            this.Get_Latest_By_TagIdsAsync(tagIds, null);
        }
        
        /// <remarks/>
        public void Get_Latest_By_TagIdsAsync(string tagIds, object userState) {
            if ((this.Get_Latest_By_TagIdsOperationCompleted == null)) {
                this.Get_Latest_By_TagIdsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_Latest_By_TagIdsOperationCompleted);
            }
            this.InvokeAsync("Get_Latest_By_TagIds", new object[] {
                        tagIds}, this.Get_Latest_By_TagIdsOperationCompleted, userState);
        }
        
        private void OnGet_Latest_By_TagIdsOperationCompleted(object arg) {
            if ((this.Get_Latest_By_TagIdsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_Latest_By_TagIdsCompleted(this, new Get_Latest_By_TagIdsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.ypwater.com/Get_Latest_All", RequestNamespace="http://service.ypwater.com/", ResponseNamespace="http://service.ypwater.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TagYearInfo[] Get_Latest_All() {
            object[] results = this.Invoke("Get_Latest_All", new object[0]);
            return ((TagYearInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void Get_Latest_AllAsync() {
            this.Get_Latest_AllAsync(null);
        }
        
        /// <remarks/>
        public void Get_Latest_AllAsync(object userState) {
            if ((this.Get_Latest_AllOperationCompleted == null)) {
                this.Get_Latest_AllOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_Latest_AllOperationCompleted);
            }
            this.InvokeAsync("Get_Latest_All", new object[0], this.Get_Latest_AllOperationCompleted, userState);
        }
        
        private void OnGet_Latest_AllOperationCompleted(object arg) {
            if ((this.Get_Latest_AllCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_Latest_AllCompleted(this, new Get_Latest_AllCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.ypwater.com/")]
    public partial class TagYearInfo {
        
        private int i_Cycle_IdField;
        
        private string i_Tag_IdField;
        
        private double i_Value_OrgField;
        
        private double i_Value_ManField;
        
        private double max_ValueField;
        
        private double min_ValueField;
        
        private double begin_ValueField;
        
        private double end_ValueField;
        
        /// <remarks/>
        public int I_Cycle_Id {
            get {
                return this.i_Cycle_IdField;
            }
            set {
                this.i_Cycle_IdField = value;
            }
        }
        
        /// <remarks/>
        public string I_Tag_Id {
            get {
                return this.i_Tag_IdField;
            }
            set {
                this.i_Tag_IdField = value;
            }
        }
        
        /// <remarks/>
        public double I_Value_Org {
            get {
                return this.i_Value_OrgField;
            }
            set {
                this.i_Value_OrgField = value;
            }
        }
        
        /// <remarks/>
        public double I_Value_Man {
            get {
                return this.i_Value_ManField;
            }
            set {
                this.i_Value_ManField = value;
            }
        }
        
        /// <remarks/>
        public double Max_Value {
            get {
                return this.max_ValueField;
            }
            set {
                this.max_ValueField = value;
            }
        }
        
        /// <remarks/>
        public double Min_Value {
            get {
                return this.min_ValueField;
            }
            set {
                this.min_ValueField = value;
            }
        }
        
        /// <remarks/>
        public double Begin_Value {
            get {
                return this.begin_ValueField;
            }
            set {
                this.begin_ValueField = value;
            }
        }
        
        /// <remarks/>
        public double End_Value {
            get {
                return this.end_ValueField;
            }
            set {
                this.end_ValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Get_By_TagId_CycleIdCompletedEventHandler(object sender, Get_By_TagId_CycleIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_By_TagId_CycleIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get_By_TagId_CycleIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TagYearInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TagYearInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Get_By_TagId_DateTimeCompletedEventHandler(object sender, Get_By_TagId_DateTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_By_TagId_DateTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get_By_TagId_DateTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TagYearInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TagYearInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Get_By_TagIds_CycleIdCompletedEventHandler(object sender, Get_By_TagIds_CycleIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_By_TagIds_CycleIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get_By_TagIds_CycleIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TagYearInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TagYearInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Get_By_TagIds_DateTimeCompletedEventHandler(object sender, Get_By_TagIds_DateTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_By_TagIds_DateTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get_By_TagIds_DateTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TagYearInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TagYearInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Get_Latest_By_TagIdCompletedEventHandler(object sender, Get_Latest_By_TagIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_Latest_By_TagIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get_Latest_By_TagIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TagYearInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TagYearInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Get_Latest_By_TagIdsCompletedEventHandler(object sender, Get_Latest_By_TagIdsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_Latest_By_TagIdsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get_Latest_By_TagIdsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TagYearInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TagYearInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Get_Latest_AllCompletedEventHandler(object sender, Get_Latest_AllCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_Latest_AllCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get_Latest_AllCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TagYearInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TagYearInfo[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591