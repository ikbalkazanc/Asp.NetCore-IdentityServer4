<div align="center">
<img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/identityserver4.jpg" alt="Logo" width="50%" height="50%">
</div>

# Identity Server
## What is Identity Server 4 
Identity server is provide many easiness to us. We can define authorization rules. And we can assing this rules to APIs and Clients. As example, client1 can do just read process in Apı2. It provides many facilities like this. We will talk about in detail later. Indentity Server is use OAuth 2 and OpenId Connect protocols. So we are required to know what they are.
#### OAuth 2.0
OAuth protocols is provide secure authorization for systems like web, mobile. We are seeing many instances in daily life as sign in to any web sites. I will tell many information about OAuth. if you want see about it You can examine <a href="https://oauth.net/2/">here</a>. 
<div align="center">
<img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/bootstrap-social.png" alt="Logo" width="20%" height="20%">
 </div>

#### OpenId Connect
OpenId Connect allows Clients to verify the identity of the End-User based on the authentication performed by an Authorization Server. if you want see about it You can examine <a href="https://openid.net/connect/">here</a>. 

## Some Important Terms
<strong>Resources :</strong> Resources are a series of identity. We will define identity rules inside resource. And we are assign to clients them. As example, we will do define just reading to in API 1 for Client1.  
<strong>Identity Token :</strong> Information about how and when the user authenticated. It can contain additional identity data.      
<strong>Access Token :</strong> We are give token to request. These are contained in client names, base urls, scopes, private key and public key. There are a lot of details, but for now, these concern us. Below is a sample token.
```
eyJhbGciOiJSUzI1NiIsImtpZCI6IjJDQzA3MEI2NjMxRTUzMEY0MjkwRUJEOEY0MzI4QzQ1IiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MDYzOTEwNzYsImV4cCI6MTYwNjM5NDY3NiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6InJlc291cmNlX2FwaTEiLCJjbGllbnRfaWQiOiJDbGllbnQxIiwianRpIjoiQjE1N0JFRjc1MkUxMzQzNzlGOUFFM0I5MzJCNkYzNTIiLCJpYXQiOjE2MDYzOTEwNzYsInNjb3BlIjpbImFwaTEucmVhZCIsImFwaTEudXBkYXRlIiwiYXBpMS53cml0ZSJdfQ.dQYwd9JLt9YGvhkxp36GSNRttSI9rYoz2KctY0FFD2XQ5X0pvyLi07FmHJik8zZnXRezXH2txwy9VkbbQ-bwEZ5cWzylmuS2fXKkUTr2wyQhV6_tyPOjluGrKBcUHkB1cL_ypXRm6ijy-i1XxVuGNjPiT0LZH9aB69RaeQn4khWAY27VFVucWkPhf3nkTvH7dOKPu-cK8cmpLPkQa7BT08cxddOqB8kK_9YZEp3wyvjTBXF_V0GfxvQfMtEp60LBx2gfXJGHm1PMftF5k0oTCZB1xYWwR_P2HY-3Edl0AwZSvz80-v2GTSm2q9RWfuLSlZVB5AvAmQyh0OfyNUx7XA
```

## OAuth 2.0 Grands (Flows)
#### Authorization Code Grant
This is so complicated. But in sum, Resource owner(user) is sending request to identity server with client identifier(username&password). This server can be facebook, twitter identity servers etc. Then server checking client identifier. if it's right it send authorization code(identity token) to client. And when client request to APIs it sending authorization code to identity server. Identity server is sending back access token and client credential. anymore client can be request to api with access token.
<div align="center">
 <img src="https://github.com/ikbalkazanc/Asp.NetCore-IdentityServer4/blob/master/images/IdentityServer4-Yazi-Serisi-8-Authorization-Code-GrantFlow.png" alt="Logo" width="40%" height="40%">
</div>
You can found more in <a href="https://tools.ietf.org/html/rfc6749#section-1.3.1">here</a> 

#### Implicit grant
bir üstekinin optimize hali. pass id doğruysa auth server direk access token gönderiyor. Kullanıcının kafa rahat.
#### Resource owner credentials grand
Ya kıral işte aynı  maktık. Kullanıcılara role atıyor.
#### Client credentials grant

## Source
https://www.gencayyildiz.com/blog/identityserver4-yazi-serisi-8-authorization-code-grantflow/
