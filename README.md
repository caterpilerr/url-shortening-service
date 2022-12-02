# url-shortening-service
This is a very simple URL shortening service.

It provides two api method:

- [POST]\
{host}/?url={url_to_shorten}\
Returns response: {host}/{shortened_url}

- [GET]\
{host}/{shortened_url}\
Return redirect to original URL, and 404 NotFound if shortened_url doesn't exist.
