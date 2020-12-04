# Api-MongoDB

This is an API developed in .NET capable of accessing a database and doing some operations:

- Post
- Get
- Put
- Delete

For Test:

https://localhost:5001/infectado

For Post you can use:

```
{
	"dataNascimento": "1995-03-01",
	"sexo": "F",
	"latitude": -23.5630994,
	"longitude": -46.6565712
}
```

Obs.: You don't need to pass an ID, MongoDB generate one



To use Put and Delete you will need to pass the Object ID, you can get it by using Get.



Remember to set your database access in appsettings.
