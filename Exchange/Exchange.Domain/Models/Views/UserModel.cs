using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Exchange.Domain.Models.Views;

public partial class UserModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private Guid id;

    [JsonPropertyName("email")]
    [ObservableProperty]
    private string email;

    [JsonPropertyName("name")]
    [ObservableProperty]
    private string name;

    public  UserModel() 
    {
        this.Id = id;
        this.Email = email;
        this.Name = name;
    }

    public UserModel(UserEntity entity)
    {
        this.Id = entity.Id;
        this.Email = entity.Email;
        this.Name = entity.FullName;
    }

    public UserEntity ToEntity()
    {
        return new UserEntity
        {
            Id = this.Id,
            Email = this.Email,
            FullName = this.Name,
        };
    }

    public void ToEntity(UserEntity entity)
    {
        entity.Id = this.Id;
        entity.Email = this.Email;
        entity.FullName = this.Name;
    }
}

    