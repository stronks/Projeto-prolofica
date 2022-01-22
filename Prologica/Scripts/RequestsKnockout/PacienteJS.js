
function PacienteViewModel() {

    //Make the self as 'this' reference
    var self = this;
    self.Id = ko.observable();
    self.Nome = ko.observable("");


    var Paciente = {
        Id: self.Id,
        Nome: self.Nome
    };

    self.Paciente = ko.observable();
    self.Pacientes = ko.observableArray([]); // Contains the list of Pacientes

    // Initialize the view-model
    $.ajax({
        url: '/api/Paciente/',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Pacientes(data.map(e => {
                return {
                    Id: e.id,
                    Nome: e.nome,
                };
            }));
        }
    });


    //Add New Item
    self.create = function () {
        if (Paciente.Nome() != "") {
            var consultorio = ko.toJSON(Paciente);
            $.ajax({
                url: '/api/Paciente/Insere',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: consultorio,
                success: function (data) {
                    self.Pacientes(data.map(e => {
                        return {
                            Id: e.id,
                            Nome: e.nome,
                        };
                    }));
                    self.Nome("");
                }
            }).fail(
                function (xhr, textStatus, err) {
                    alert(xhr.responseJSON.message);
                });
        }
        else {
            alert('Preenchimento do Nome obrigatorio.');
        }
    }
    // Delete Paciente details
    self.delete = function (Paciente) {
        if (confirm('Tem certeza que deseja cancelar "' + Paciente.Nome + '" ?')) {
            var id = Paciente.Id;

            $.ajax({
                url: '/api/Paciente/Delete/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: id,
                success: function (data) {
                    self.Pacientes.remove(Paciente);
                    self.Pacientes(data.map(e => {
                        return {
                            Id: e.id,
                            Nome: e.nome,
                        };
                    }));
                }
            }).fail(
                function (xhr, textStatus, err) {
                    alert(xhr.responseJSON.message);
             
                });
        }
    }

    // Edit Paciente details
    self.edit = function (consultorio) {
        self.Paciente(consultorio);
    }

    // Update Paciente details
    self.update = function () {
        var Paciente = self.Paciente();

        $.ajax({
            url: '/api/Paciente/Update',
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Paciente),
            success: function (data) {
                self.Pacientes.removeAll();
                self.Pacientes(data.map(e => {
                    return {
                        Id: e.id,
                        Nome: e.nome,
                    };
                }));
                self.Paciente(null);

            }
        })
            .fail(
                function (xhr, textStatus, err) {
                    alert(xhr.responseJSON.message);
                });
    }

    // Reset Paciente details
    self.reset = function () {
        self.Nome("");

    }

    // Cancel Paciente details
    self.cancel = function () {
        self.Paciente(null);
    }
}
var viewModel = new PacienteViewModel();
ko.applyBindings(viewModel);
