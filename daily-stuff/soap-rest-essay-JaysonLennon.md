# REST & SOAP

## REST
REST is short for "Representational State Transfer".
It is simply a way for programs to communicate over the web using a universal data format while following general guidelines for operation.
The universal data format used for REST requests is JSON.
The anatomy of a REST request consists of: an endpoint URL, an HTTP method, authentication headers (if applicable), and possibly JSON data.

An endpoint URL is simply a URL that points to a REST API.
An example is `http://example.com/user/1` where `user` is the type of entity being requested, and `1` is the specific entity.
A RESTful web service should return data related to _user 1_ in this case, and the data should represent the current state of _user 1_.
The format returned would be in JSON, for example:
```
{
    "id": 1,
    "name": "sample user"
}
```

The HTTP method plays a crucial role in the construction of a RESTful API.
`GET` methods should only query data from the API, while `PUT` and `POST` should create or edit data at the API.
It is optional which HTTP methods an API implements and it should only implement the methods that are relevant for using the API.

Authentication headers are important in order to be able to restrict access to the API.
Without the headers, anyone who visits the API would be able to get full access to all information available at the API, regardless whether they should have access.
This access can be presented in the `Authorization` header, or by making a custom header such as `X-Api-Key`.
All API requests that require authorization must use HTTPS, otherwise they authentication key may be tampered with or copied by attackers.

Lastly, JSON data may be included in the request body of, for example, a `POST` request.
This would allow the client to send additional data or instructions to the RESTful API so it may properly carry out the request.
An example of `POST` data that would likely be sent is when updating shipping information for a package: all updated fields can be sent in the _body_ of the request, and the unchanged fields could be omitted.
This would be an indication to the RESTful API that only part of the shipping information needs to be updated, and the API should then perform the update properly.

## SOAP
SOAP is short for Simple Object Access Protocol.
Similar to REST, it is a way for applications to communicate across networks using a pre-defined format (XML).
However, unlike REST, SOAP requires a heavy amount of structure compared to REST.

SOAP requests are made with an XML SOAP message that contains: an envelope, optional headers, and at least one body message.

The _envelope_ is the root element of a SOAP message and required for all requests and responses.
It simply defines which SOAP version is being used and the _encoding style_, which determines the data type of the message.

The _header_ specifies the recipient of the SOAP header, and whether the recipient must understand and process the header.
If the recipient is unable to process the header, and the header is defined to require header processing, then the recipient should return a _fault_.

Lastly, the _body_ of a SOAP message is the data that is intended for the final recipient of the message.
It is application-specific, and applications are permitted to use any amount of information needed for the message to be useful.
The body is contained with XML tags, and each application-specific piece of data should be in it's own XML tag.

Sometimes errors may occur when using SOAP messaging, and when that happens a _fault_ gets returned.
Faults have four components: a fault code, a fault string, a fault actor, and fault detail.
A fault code is a code that specifies a predefined error type specific to the SOAP protocol.
A fault string is simply a string of text that describes the fault that occurred.
The fault actor is a string that notes which node (or actor) raised the fault.
Lastly, the fault detail is an application-specific error message and it may contain additional nodes that further describe the fault (if necessary).
