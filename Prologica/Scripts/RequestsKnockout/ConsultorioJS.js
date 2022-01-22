
function ConsultorioViewModel() {

    //Make the self as 'this' reference
    var self = this;
    self.Id = ko.observable();
    self.Nome = ko.observable("");


    var Consultorio = {
        Id: self.Id,
        Nome: self.Nome
    };

    self.Consultorio = ko.observable();
    self.Consultorios = ko.observableArray([]); // Contains the list of Consultorios

    // Initialize the view-model
    $.ajax({
        url: '/api/Consultorio',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Consultorios(data.map(e => {
                return {
                    Id: e.id,
                    Nome: e.nome,
                };
            }));
        }
    });


    //Add New Item
    self.create = function () {
        if (Consultorio.Nome() != "") {
            var consultorio = ko.toJSON(Consultorio);
            $.ajax({
                url: '/api/Consultorio/Insere',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: consultorio,
                success: function (data) {
                    self.Consultorios(data.map(e => {
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
    // Delete Consultorio details
    self.delete = function (Consultorio) {
        if (confirm('Tem certeza que deseja cancelar "' + Consultorio.Nome + '" ?')) {
            var id = Consultorio.Id;

            $.ajax({
                url: '/api/Consultorio/Delete/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: id,
                success: function (data) {
                    self.Consultorios.remove(Consultorio);
                    self.Consultorios(data.map(e => {
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

    // Edit Consultorio details
    self.edit = function (consultorio) {
        self.Consultorio(consultorio);
    }

    // Update Consultorio details
    self.update = function () {
        var Consultorio = self.Consultorio();

        $.ajax({
            url: '/api/Consultorio/Update',
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Consultorio),
            success: function (data) {
                self.Consultorios.removeAll();
                self.Consultorios(data.map(e => {
                    return {
                        Id: e.id,
                        Nome: e.nome,
                    };
                }));
                self.Consultorio(null);
         
            }
        })
            .fail(
                function (xhr, textStatus, err) {
                    alert(xhr.responseJSON.message);
                });
    }

    // Reset Consultorio details
    self.reset = function () {
        self.Nome("");

    }

    // Cancel Consultorio details
    self.cancel = function () {
        self.Consultorio(null);
    }
}
var viewModel = new ConsultorioViewModel();
ko.applyBindings(viewModel);
