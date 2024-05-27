using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

/** Servidor **/
[CreateAssetMenu(fileName = "Server", menuName = "Minigames/Server", order = 1)]
public class Server : ScriptableObject
{
    /** Url del servidor **/
    public string server;

    /** Lista de servicios **/
    public Service[] services;

    /** Bool para saber si esta ocupado el servicio **/
    public bool inUse;

    /** Referencia a la Respuesta **/
    public Response response;
    
    public IEnumerator UseService(string name, string[] data, UnityAction e)
    {
        /** Establece el bool en true **/
        inUse = true;

        /** Formulario **/
        WWWForm form = new WWWForm();

        /** Crea un servicio **/
        Service service = new Service();

        /** Itera sobre la lista de servicios **/
        for (int i = 0; i < services.Length; i++)
        {
            /** Si el servicio sobre el que esta iterando se llama igual que el nombre que recibe **/
            if (services[i].name.Equals(name))
            {
                /** Establece el servicio igual al que se le ha pasado **/
                service = services[i];
            }
        }

        /** Itera sobre los parametros de los servicios **/
        for (int i = 0; i < service.parameters.Length; i++)
        {
            /** Añade los parametros **/
            form.AddField(service.parameters[i], data[i]);
        }

        /** Crea una peticion **/
        UnityWebRequest www = UnityWebRequest.Post(server + "/" + service.url, form);

        /** Imprime la url de donde se manda la peticion **/
        Debug.Log(server + "/" + service.url);

        /** Espera a que la peticion se complete **/
        yield return www.SendWebRequest();

        /** Si el resultado no es exitoso **/
        if (www.result != UnityWebRequest.Result.Success)
        {
            /** Iguala la respuesta a la respuesta por defecto de error **/
            response = new Response();
        } 
        
        /** Si el resultado ha sido exitoso **/
        else
        {
            /** Imprime el json **/
            Debug.Log(www.downloadHandler.text);

            /** Convierte el json en una respuesta **/
            response = JsonUtility.FromJson<Response>(www.downloadHandler.text);

            /** Llama al metodo FormatResponse() **/
            response.FormatResponse();
        }

        /** Establece que el servicio no esta en uso **/
        inUse = false;

        /** Invoca el evento **/
        e.Invoke();
    }
    
}

/** Servicio **/
[System.Serializable]
public class Service
{
    /** Nombre del servicio **/
    public string name;

    /** Url del servicio **/
    public string url;

    /** Parametros del servicio **/
    public string[] parameters;
}

/** Respuesta del servicio **/
[System.Serializable]
public class Response
{
    /** Codigo de la respuesta **/
    public int codigo;

    /** Mensaje de la resouesta **/
    public string mensaje;

    /** Respuesta **/
    public string respuesta;

    /** Metodo para corregit el formato del json **/
    public void FormatResponse()
    {
        /** Remplaza '#' por '"' **/
        respuesta = respuesta.Replace('#', '"');
    }

    public Response()
    {
        codigo = 404;
        mensaje = "Error";
    }
}

[System.Serializable]
public class DB_Users
{
    public int user_id;
    public string username;
    public string password;
    public int nivel;
}