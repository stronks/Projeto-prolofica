
function MedicoViewModel() {

    //Make the self as 'this' reference
    var self = this;
    self.Id = ko.observable();
    self.Nome = ko.observable("");


    var Medico = {
        Id: self.Id,
        Nome: self.Nome
    };

    self.Medico = ko.observable();
    self.Medicos = ko.observableArray([]); // Contains the list of Medicos

    // Initialize the view-model
    $.ajax({
        url: '/api/Medico',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Medicos(data.map(e => {
                return {
                    Id: e.id,
                    Nome: e.nome,
                };
            }));
        }
    });


    //Add New Item
    self.create = function () {
        if (Medico.Nome() != "") {
            var consultorio = ko.toJSON(Medico);
            $.ajax({
                url: '/api/Medico/Insere',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: consultorio,
                success: function (data) {
                    self.Medicos(data.map(e => {
                        return {
                            Id: e.id,
                            Nome: e.nome,
                        };
                    }));
                    self.Nome("");
                }
            }).fail(
                function (xhr, textStatus, err) {
                    alert(err);
                });
        }
        else {
            alert('Preenchimento do Nome obrigatorio.');
        }
    }
    // Delete Medico details
    self.delete = function (Medico) {
        if (confirm('Tem certeza que deseja cancelar "' + Medico.Nome + '" ?')) {
            var id = Medico.Id;

            $.ajax({
                url: '/api/Medico/Delete/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: id,
                success: function (data) {
                    self.Medicos.remove(Medico);
                    self.Medicos(data.map(e => {
                        return {
                            Id: e.id,
                            Nome: e.nome,
                        };
                    }));
                }
            }).fail(
                function (xhr, textStatus, err) {
                    self.status(err);
                });
        }
    }

    // Edit Medico details
    self.edit = function (consultorio) {
        self.Medico(consultorio);
    }

    // Update Medico details
    self.update = function () {
        var Medico = self.Medico();

        $.ajax({
            url: '/api/Medico/Update',
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Medico),
            success: function (data) {
                self.Medicos.removeAll();
                self.Medicos(data.map(e => {
                    return {
                        Id: e.id,
                        Nome: e.nome,
                    };
                }));
                self.Medico(null);
         
            }
        })
            .fail(
                function (xhr, textStatus, err) {
                    alert(xhr.responseJSON.message);
                });
    }

    // Reset Medico details
    self.reset = function () {
        self.Nome("");

    }

    // Cancel Medico details
    self.cancel = function () {
        self.Medico(null);
    }
}
var viewModel = new MedicoViewModel();
ko.applyBindings(viewModel);
