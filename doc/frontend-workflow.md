# Set up front-end workflow w/API spoofing

## Initial setup
1) From the project root directory, run:

```
npm install @angular/cli
```

2) Download `frontend-host` from [here](https://github.com/jayson-lennon/frontend-host/releases).

3) Extract the archive, and copy the `frontend-host` binary into `ClientApp` directory.

## After initial setup
Open two terminals:

In the first terminal:

```
cd ClientApp
../node_modules/@angular/cli/bin/ng build --watch
```

In the second terminal:

```
cd ClientApp
./frontend-host --static-dir dist
```

Open browser to `http://localhost:8000`.

Changes will be rebuilt automatically, but the browser will need to be manually refreshed.


# Spoof API requests
To create an API endpoint, make a new JSON file in the `ClientApp/api` directory with the data that you want to be returned from the server.
The data should be the same data that is expected to be returned from the application server as if it were fully functional with a database.

## Example
An API dictates that this data be returned when accessing `/api/User/1`:
```
{
    "id": 1,
    "name": "User name"
}
```

All that is needed to spoof this API is to create a JSON file with the above information under `api/User/1.json`, and the `frontend-host` will return that JSON data when `/api/User/1` is accessed.