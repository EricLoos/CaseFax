﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace HFDrelays.com.cdyne.wsf {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WeatherSoap", Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class Weather : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetWeatherInformationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCityForecastByZIPOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCityWeatherByZIPOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Weather() {
            this.Url = global::HFDrelays.Properties.Settings.Default.HFDrelays_com_cdyne_wsf_Weather;
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
        public event GetWeatherInformationCompletedEventHandler GetWeatherInformationCompleted;
        
        /// <remarks/>
        public event GetCityForecastByZIPCompletedEventHandler GetCityForecastByZIPCompleted;
        
        /// <remarks/>
        public event GetCityWeatherByZIPCompletedEventHandler GetCityWeatherByZIPCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.cdyne.com/WeatherWS/GetWeatherInformation", RequestNamespace="http://ws.cdyne.com/WeatherWS/", ResponseNamespace="http://ws.cdyne.com/WeatherWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public WeatherDescription[] GetWeatherInformation() {
            object[] results = this.Invoke("GetWeatherInformation", new object[0]);
            return ((WeatherDescription[])(results[0]));
        }
        
        /// <remarks/>
        public void GetWeatherInformationAsync() {
            this.GetWeatherInformationAsync(null);
        }
        
        /// <remarks/>
        public void GetWeatherInformationAsync(object userState) {
            if ((this.GetWeatherInformationOperationCompleted == null)) {
                this.GetWeatherInformationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetWeatherInformationOperationCompleted);
            }
            this.InvokeAsync("GetWeatherInformation", new object[0], this.GetWeatherInformationOperationCompleted, userState);
        }
        
        private void OnGetWeatherInformationOperationCompleted(object arg) {
            if ((this.GetWeatherInformationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetWeatherInformationCompleted(this, new GetWeatherInformationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.cdyne.com/WeatherWS/GetCityForecastByZIP", RequestNamespace="http://ws.cdyne.com/WeatherWS/", ResponseNamespace="http://ws.cdyne.com/WeatherWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ForecastReturn GetCityForecastByZIP(string ZIP) {
            object[] results = this.Invoke("GetCityForecastByZIP", new object[] {
                        ZIP});
            return ((ForecastReturn)(results[0]));
        }
        
        /// <remarks/>
        public void GetCityForecastByZIPAsync(string ZIP) {
            this.GetCityForecastByZIPAsync(ZIP, null);
        }
        
        /// <remarks/>
        public void GetCityForecastByZIPAsync(string ZIP, object userState) {
            if ((this.GetCityForecastByZIPOperationCompleted == null)) {
                this.GetCityForecastByZIPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCityForecastByZIPOperationCompleted);
            }
            this.InvokeAsync("GetCityForecastByZIP", new object[] {
                        ZIP}, this.GetCityForecastByZIPOperationCompleted, userState);
        }
        
        private void OnGetCityForecastByZIPOperationCompleted(object arg) {
            if ((this.GetCityForecastByZIPCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCityForecastByZIPCompleted(this, new GetCityForecastByZIPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.cdyne.com/WeatherWS/GetCityWeatherByZIP", RequestNamespace="http://ws.cdyne.com/WeatherWS/", ResponseNamespace="http://ws.cdyne.com/WeatherWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public WeatherReturn GetCityWeatherByZIP(string ZIP) {
            object[] results = this.Invoke("GetCityWeatherByZIP", new object[] {
                        ZIP});
            return ((WeatherReturn)(results[0]));
        }
        
        /// <remarks/>
        public void GetCityWeatherByZIPAsync(string ZIP) {
            this.GetCityWeatherByZIPAsync(ZIP, null);
        }
        
        /// <remarks/>
        public void GetCityWeatherByZIPAsync(string ZIP, object userState) {
            if ((this.GetCityWeatherByZIPOperationCompleted == null)) {
                this.GetCityWeatherByZIPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCityWeatherByZIPOperationCompleted);
            }
            this.InvokeAsync("GetCityWeatherByZIP", new object[] {
                        ZIP}, this.GetCityWeatherByZIPOperationCompleted, userState);
        }
        
        private void OnGetCityWeatherByZIPOperationCompleted(object arg) {
            if ((this.GetCityWeatherByZIPCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCityWeatherByZIPCompleted(this, new GetCityWeatherByZIPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class WeatherDescription {
        
        private short weatherIDField;
        
        private string descriptionField;
        
        private string pictureURLField;
        
        /// <remarks/>
        public short WeatherID {
            get {
                return this.weatherIDField;
            }
            set {
                this.weatherIDField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string PictureURL {
            get {
                return this.pictureURLField;
            }
            set {
                this.pictureURLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class WeatherReturn {
        
        private bool successField;
        
        private string responseTextField;
        
        private string stateField;
        
        private string cityField;
        
        private string weatherStationCityField;
        
        private short weatherIDField;
        
        private string descriptionField;
        
        private string temperatureField;
        
        private string relativeHumidityField;
        
        private string windField;
        
        private string pressureField;
        
        private string visibilityField;
        
        private string windChillField;
        
        private string remarksField;
        
        /// <remarks/>
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
            }
        }
        
        /// <remarks/>
        public string ResponseText {
            get {
                return this.responseTextField;
            }
            set {
                this.responseTextField = value;
            }
        }
        
        /// <remarks/>
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public string WeatherStationCity {
            get {
                return this.weatherStationCityField;
            }
            set {
                this.weatherStationCityField = value;
            }
        }
        
        /// <remarks/>
        public short WeatherID {
            get {
                return this.weatherIDField;
            }
            set {
                this.weatherIDField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string Temperature {
            get {
                return this.temperatureField;
            }
            set {
                this.temperatureField = value;
            }
        }
        
        /// <remarks/>
        public string RelativeHumidity {
            get {
                return this.relativeHumidityField;
            }
            set {
                this.relativeHumidityField = value;
            }
        }
        
        /// <remarks/>
        public string Wind {
            get {
                return this.windField;
            }
            set {
                this.windField = value;
            }
        }
        
        /// <remarks/>
        public string Pressure {
            get {
                return this.pressureField;
            }
            set {
                this.pressureField = value;
            }
        }
        
        /// <remarks/>
        public string Visibility {
            get {
                return this.visibilityField;
            }
            set {
                this.visibilityField = value;
            }
        }
        
        /// <remarks/>
        public string WindChill {
            get {
                return this.windChillField;
            }
            set {
                this.windChillField = value;
            }
        }
        
        /// <remarks/>
        public string Remarks {
            get {
                return this.remarksField;
            }
            set {
                this.remarksField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class POP {
        
        private string nighttimeField;
        
        private string daytimeField;
        
        /// <remarks/>
        public string Nighttime {
            get {
                return this.nighttimeField;
            }
            set {
                this.nighttimeField = value;
            }
        }
        
        /// <remarks/>
        public string Daytime {
            get {
                return this.daytimeField;
            }
            set {
                this.daytimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class temp {
        
        private string morningLowField;
        
        private string daytimeHighField;
        
        /// <remarks/>
        public string MorningLow {
            get {
                return this.morningLowField;
            }
            set {
                this.morningLowField = value;
            }
        }
        
        /// <remarks/>
        public string DaytimeHigh {
            get {
                return this.daytimeHighField;
            }
            set {
                this.daytimeHighField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class Forecast {
        
        private System.DateTime dateField;
        
        private short weatherIDField;
        
        private string desciptionField;
        
        private temp temperaturesField;
        
        private POP probabilityOfPrecipiationField;
        
        /// <remarks/>
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        public short WeatherID {
            get {
                return this.weatherIDField;
            }
            set {
                this.weatherIDField = value;
            }
        }
        
        /// <remarks/>
        public string Desciption {
            get {
                return this.desciptionField;
            }
            set {
                this.desciptionField = value;
            }
        }
        
        /// <remarks/>
        public temp Temperatures {
            get {
                return this.temperaturesField;
            }
            set {
                this.temperaturesField = value;
            }
        }
        
        /// <remarks/>
        public POP ProbabilityOfPrecipiation {
            get {
                return this.probabilityOfPrecipiationField;
            }
            set {
                this.probabilityOfPrecipiationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class ForecastReturn {
        
        private bool successField;
        
        private string responseTextField;
        
        private string stateField;
        
        private string cityField;
        
        private string weatherStationCityField;
        
        private Forecast[] forecastResultField;
        
        /// <remarks/>
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
            }
        }
        
        /// <remarks/>
        public string ResponseText {
            get {
                return this.responseTextField;
            }
            set {
                this.responseTextField = value;
            }
        }
        
        /// <remarks/>
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public string WeatherStationCity {
            get {
                return this.weatherStationCityField;
            }
            set {
                this.weatherStationCityField = value;
            }
        }
        
        /// <remarks/>
        public Forecast[] ForecastResult {
            get {
                return this.forecastResultField;
            }
            set {
                this.forecastResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void GetWeatherInformationCompletedEventHandler(object sender, GetWeatherInformationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetWeatherInformationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetWeatherInformationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WeatherDescription[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WeatherDescription[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void GetCityForecastByZIPCompletedEventHandler(object sender, GetCityForecastByZIPCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCityForecastByZIPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCityForecastByZIPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ForecastReturn Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ForecastReturn)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void GetCityWeatherByZIPCompletedEventHandler(object sender, GetCityWeatherByZIPCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCityWeatherByZIPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCityWeatherByZIPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WeatherReturn Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WeatherReturn)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591