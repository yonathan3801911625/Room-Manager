function guardarUsuario(){
    $.ajax({
        url: 'https://localhost:44375/api/Usuario/InsertarUsuarioAsync',
        
        type: 'POST',
        data: JSON.stringify({
            "pkIdUsuario": 0,
            "nombreUsuario": document.getElementById('nombreUsuario').value,
            "identificacionUsuario": document.getElementById('idenUsuario').value,
            "contraseñaUsuario": document.getElementById('contrasena').value,
            "fkIdRol": "1"
          }),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (datos) {
            


            //$('#modal1').html(modal);
            alert('Inserción Exitosa!');
            window.location.replace("Read.html")
        },
        error: function () {
            alert('Petición con error');
        }
    });


}

