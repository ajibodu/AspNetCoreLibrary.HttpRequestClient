# AspNetCoreLibrary.HttpRequestClient
HttpRequestClient

### Initialize client _with expected response object **RespObj** _
`HttpRequestClient<RespObj> client = new HttpRequestClient<RespObj>(requestURL);`

### Add Request Header
`client.Request.Headers.Add("X-ApiAuthentication", APIKey);`

### **GET** Request  _This would return response as **RespObj** _
`var resp =  client.Get();`

### **GET** Request  _This would return response as **string** _
`var resp =  client.GetStrng();`

### **POST** Request  _This would return response as **RespObj** _
`var resp =  client.Post(JsonConvert.SerializeObject(requestObject), PostType.String);`

### **POST** Request  _This would return response as **string** _
`var resp =  client.PostString(JsonConvert.SerializeObject(request), PostType.String);`

### Access HttpWebResponse
`HttpWebResponse response = client.Response;`
