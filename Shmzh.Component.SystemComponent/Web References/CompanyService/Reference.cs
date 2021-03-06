﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.1 版自动生成。
// 
#pragma warning disable 1591

namespace Shmzh.Components.SystemComponent.CompanyService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CompanySoap", Namespace="http://tempuri.org/")]
    public partial class Company : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback InsertOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsExistCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsExistNameOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllAvalibleOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetByCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDefaultOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Company() {
            this.Url = global::Shmzh.Components.SystemComponent.Properties.Settings.Default.Shmzh_Components_SystemComponent_CompanyService_Company;
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
        public event InsertCompletedEventHandler InsertCompleted;
        
        /// <remarks/>
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        /// <remarks/>
        public event DeleteCompletedEventHandler DeleteCompleted;
        
        /// <remarks/>
        public event IsExistCodeCompletedEventHandler IsExistCodeCompleted;
        
        /// <remarks/>
        public event IsExistNameCompletedEventHandler IsExistNameCompleted;
        
        /// <remarks/>
        public event GetAllCompletedEventHandler GetAllCompleted;
        
        /// <remarks/>
        public event GetAllAvalibleCompletedEventHandler GetAllAvalibleCompleted;
        
        /// <remarks/>
        public event GetByCodeCompletedEventHandler GetByCodeCompleted;
        
        /// <remarks/>
        public event GetDefaultCompletedEventHandler GetDefaultCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Insert", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Insert(CompanyInfo companyInfo) {
            object[] results = this.Invoke("Insert", new object[] {
                        companyInfo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void InsertAsync(CompanyInfo companyInfo) {
            this.InsertAsync(companyInfo, null);
        }
        
        /// <remarks/>
        public void InsertAsync(CompanyInfo companyInfo, object userState) {
            if ((this.InsertOperationCompleted == null)) {
                this.InsertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertOperationCompleted);
            }
            this.InvokeAsync("Insert", new object[] {
                        companyInfo}, this.InsertOperationCompleted, userState);
        }
        
        private void OnInsertOperationCompleted(object arg) {
            if ((this.InsertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertCompleted(this, new InsertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Update(CompanyInfo companyInfo) {
            object[] results = this.Invoke("Update", new object[] {
                        companyInfo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateAsync(CompanyInfo companyInfo) {
            this.UpdateAsync(companyInfo, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(CompanyInfo companyInfo, object userState) {
            if ((this.UpdateOperationCompleted == null)) {
                this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
            }
            this.InvokeAsync("Update", new object[] {
                        companyInfo}, this.UpdateOperationCompleted, userState);
        }
        
        private void OnUpdateOperationCompleted(object arg) {
            if ((this.UpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCompleted(this, new UpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Delete", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Delete(string coCode) {
            object[] results = this.Invoke("Delete", new object[] {
                        coCode});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteAsync(string coCode) {
            this.DeleteAsync(coCode, null);
        }
        
        /// <remarks/>
        public void DeleteAsync(string coCode, object userState) {
            if ((this.DeleteOperationCompleted == null)) {
                this.DeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteOperationCompleted);
            }
            this.InvokeAsync("Delete", new object[] {
                        coCode}, this.DeleteOperationCompleted, userState);
        }
        
        private void OnDeleteOperationCompleted(object arg) {
            if ((this.DeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCompleted(this, new DeleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsExistCode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsExistCode(string coCode) {
            object[] results = this.Invoke("IsExistCode", new object[] {
                        coCode});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsExistCodeAsync(string coCode) {
            this.IsExistCodeAsync(coCode, null);
        }
        
        /// <remarks/>
        public void IsExistCodeAsync(string coCode, object userState) {
            if ((this.IsExistCodeOperationCompleted == null)) {
                this.IsExistCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsExistCodeOperationCompleted);
            }
            this.InvokeAsync("IsExistCode", new object[] {
                        coCode}, this.IsExistCodeOperationCompleted, userState);
        }
        
        private void OnIsExistCodeOperationCompleted(object arg) {
            if ((this.IsExistCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsExistCodeCompleted(this, new IsExistCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsExistName", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsExistName(string coCnName) {
            object[] results = this.Invoke("IsExistName", new object[] {
                        coCnName});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsExistNameAsync(string coCnName) {
            this.IsExistNameAsync(coCnName, null);
        }
        
        /// <remarks/>
        public void IsExistNameAsync(string coCnName, object userState) {
            if ((this.IsExistNameOperationCompleted == null)) {
                this.IsExistNameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsExistNameOperationCompleted);
            }
            this.InvokeAsync("IsExistName", new object[] {
                        coCnName}, this.IsExistNameOperationCompleted, userState);
        }
        
        private void OnIsExistNameOperationCompleted(object arg) {
            if ((this.IsExistNameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsExistNameCompleted(this, new IsExistNameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAll", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CompanyInfo[] GetAll() {
            object[] results = this.Invoke("GetAll", new object[0]);
            return ((CompanyInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllAsync() {
            this.GetAllAsync(null);
        }
        
        /// <remarks/>
        public void GetAllAsync(object userState) {
            if ((this.GetAllOperationCompleted == null)) {
                this.GetAllOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllOperationCompleted);
            }
            this.InvokeAsync("GetAll", new object[0], this.GetAllOperationCompleted, userState);
        }
        
        private void OnGetAllOperationCompleted(object arg) {
            if ((this.GetAllCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllCompleted(this, new GetAllCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllAvalible", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CompanyInfo[] GetAllAvalible() {
            object[] results = this.Invoke("GetAllAvalible", new object[0]);
            return ((CompanyInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllAvalibleAsync() {
            this.GetAllAvalibleAsync(null);
        }
        
        /// <remarks/>
        public void GetAllAvalibleAsync(object userState) {
            if ((this.GetAllAvalibleOperationCompleted == null)) {
                this.GetAllAvalibleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllAvalibleOperationCompleted);
            }
            this.InvokeAsync("GetAllAvalible", new object[0], this.GetAllAvalibleOperationCompleted, userState);
        }
        
        private void OnGetAllAvalibleOperationCompleted(object arg) {
            if ((this.GetAllAvalibleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllAvalibleCompleted(this, new GetAllAvalibleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetByCode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CompanyInfo GetByCode(string companyCode) {
            object[] results = this.Invoke("GetByCode", new object[] {
                        companyCode});
            return ((CompanyInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetByCodeAsync(string companyCode) {
            this.GetByCodeAsync(companyCode, null);
        }
        
        /// <remarks/>
        public void GetByCodeAsync(string companyCode, object userState) {
            if ((this.GetByCodeOperationCompleted == null)) {
                this.GetByCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetByCodeOperationCompleted);
            }
            this.InvokeAsync("GetByCode", new object[] {
                        companyCode}, this.GetByCodeOperationCompleted, userState);
        }
        
        private void OnGetByCodeOperationCompleted(object arg) {
            if ((this.GetByCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetByCodeCompleted(this, new GetByCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDefault", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CompanyInfo GetDefault() {
            object[] results = this.Invoke("GetDefault", new object[0]);
            return ((CompanyInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetDefaultAsync() {
            this.GetDefaultAsync(null);
        }
        
        /// <remarks/>
        public void GetDefaultAsync(object userState) {
            if ((this.GetDefaultOperationCompleted == null)) {
                this.GetDefaultOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDefaultOperationCompleted);
            }
            this.InvokeAsync("GetDefault", new object[0], this.GetDefaultOperationCompleted, userState);
        }
        
        private void OnGetDefaultOperationCompleted(object arg) {
            if ((this.GetDefaultCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDefaultCompleted(this, new GetDefaultCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CompanyInfo {
        
        private string coCodeField;
        
        private string coNameField;
        
        private string coEnNameField;
        
        private string coShortNameField;
        
        private string parentCoField;
        
        private string parentCoNameField;
        
        private string artificialPersonField;
        
        private string mgrField;
        
        private string bussinessLicenseField;
        
        private string bussinessRangeField;
        
        private string coAreaField;
        
        private string coAddressField;
        
        private string isValidField;
        
        private string remarkField;
        
        private string isDefaultField;
        
        /// <remarks/>
        public string CoCode {
            get {
                return this.coCodeField;
            }
            set {
                this.coCodeField = value;
            }
        }
        
        /// <remarks/>
        public string CoName {
            get {
                return this.coNameField;
            }
            set {
                this.coNameField = value;
            }
        }
        
        /// <remarks/>
        public string CoEnName {
            get {
                return this.coEnNameField;
            }
            set {
                this.coEnNameField = value;
            }
        }
        
        /// <remarks/>
        public string CoShortName {
            get {
                return this.coShortNameField;
            }
            set {
                this.coShortNameField = value;
            }
        }
        
        /// <remarks/>
        public string ParentCo {
            get {
                return this.parentCoField;
            }
            set {
                this.parentCoField = value;
            }
        }
        
        /// <remarks/>
        public string ParentCoName {
            get {
                return this.parentCoNameField;
            }
            set {
                this.parentCoNameField = value;
            }
        }
        
        /// <remarks/>
        public string ArtificialPerson {
            get {
                return this.artificialPersonField;
            }
            set {
                this.artificialPersonField = value;
            }
        }
        
        /// <remarks/>
        public string Mgr {
            get {
                return this.mgrField;
            }
            set {
                this.mgrField = value;
            }
        }
        
        /// <remarks/>
        public string BussinessLicense {
            get {
                return this.bussinessLicenseField;
            }
            set {
                this.bussinessLicenseField = value;
            }
        }
        
        /// <remarks/>
        public string BussinessRange {
            get {
                return this.bussinessRangeField;
            }
            set {
                this.bussinessRangeField = value;
            }
        }
        
        /// <remarks/>
        public string CoArea {
            get {
                return this.coAreaField;
            }
            set {
                this.coAreaField = value;
            }
        }
        
        /// <remarks/>
        public string CoAddress {
            get {
                return this.coAddressField;
            }
            set {
                this.coAddressField = value;
            }
        }
        
        /// <remarks/>
        public string IsValid {
            get {
                return this.isValidField;
            }
            set {
                this.isValidField = value;
            }
        }
        
        /// <remarks/>
        public string Remark {
            get {
                return this.remarkField;
            }
            set {
                this.remarkField = value;
            }
        }
        
        /// <remarks/>
        public string IsDefault {
            get {
                return this.isDefaultField;
            }
            set {
                this.isDefaultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertCompletedEventHandler(object sender, InsertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateCompletedEventHandler(object sender, UpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DeleteCompletedEventHandler(object sender, DeleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void IsExistCodeCompletedEventHandler(object sender, IsExistCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsExistCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsExistCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void IsExistNameCompletedEventHandler(object sender, IsExistNameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsExistNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsExistNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetAllCompletedEventHandler(object sender, GetAllCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CompanyInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CompanyInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetAllAvalibleCompletedEventHandler(object sender, GetAllAvalibleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllAvalibleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllAvalibleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CompanyInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CompanyInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetByCodeCompletedEventHandler(object sender, GetByCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetByCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetByCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CompanyInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CompanyInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetDefaultCompletedEventHandler(object sender, GetDefaultCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDefaultCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDefaultCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CompanyInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CompanyInfo)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591