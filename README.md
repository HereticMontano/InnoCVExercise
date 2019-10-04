### DotNet Exercise

You have to develop a rest web service for an IUD (AKA CRUD) example application. 

There is no any special requirement except do it in a semantic way.

Other optional and desirable features:
(Choose those which you feel comfortable with)

  - HTTP verbs
  - Entity validation
  - Global exception handling
  - Custom HTTP error codes
  - Unit testing
  - Asynchronous Programming
  - Dependency Management (maven, gradle or nuget)
  - Connect it to a database (in memory or localdb)

#### Suggestions

Feel free to use any framework or third party library you like. If you feel it is not the obvious choice, please justify yourself. 

Small files and semantic folder structure will be appreciated. Keeping the Single Responsibility of classes will make you look extraordinary

We like annotations if you are developing Java. We love dependency injection in any case.

We know is a very stupid simple app (it’s an exercise), but work thinking it’s the beginning of a larger project. Some elements have no sense for the IUD requirement (separation in different namespaces/packages, etc.) but it would be great if anyone want to add the IUD for another entity.

We are very (VERY) strict with naming and conventions (the “other” hard problem). There is no Good Convention, just choose one and keep it coherent. Code in English, this is the main reason we send you this in English. 

Publish your project in a public repository or in a public free web service. 

#### API
- Data format: **JSON**

#### User Model

``` c#
class User {
  [Key]
  public int Id { get; set; }
  public string Name { get; set; }
  public DateTime Birthdate { get; set; }
}
```

#### Endpoints
- You can find an API example [here](https://hello-world.innocv.com/swagger).