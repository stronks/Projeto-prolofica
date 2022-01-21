
function AgendamentoViewModel() {

    //Make the self as 'this' reference
    var self = this;


    self.Medico = ko.observable();
    self.Consultorio = ko.observable();
    self.Paciente = ko.observable();
    self.DataHoraMarcada = ko.observable();





    var Agendamento = {
        DataHoraMarcada: self.DataHoraMarcada,
        Medico: self.Medico,
        Consultorio: self.Consultorio,
        Paciente: self.Paciente
    };


    self.Id = ko.observable();
    self.Nome = ko.observable("");
    

    self.Consultorios = ko.observableArray([]);
    self.Medicos = ko.observableArray([]);
    self.Pacientes = ko.observableArray([]);


    self.Agendamento = ko.observable();
    self.Agendamentos = ko.observableArray([]);










    // Initialize the view-model
    $.ajax({
        url: '/api/HorarioAgenda',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Agendamentos(data.map(e => {
                return {
                    Id: e.id,
                    DataHoraMarcada: e.dataHoraMarcada,
                    Medico: e.medico,
                    Consultorio: e.consultorio,
                    Paciente: e.paciente
                };
            }));
        }
    });


    $.ajax({
        url: '/api/Medico',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Medicos(data.map(e => {
                return {
                    id: e.id,
                    name: e.nome,
                };
            }));
        }
    });


    $.ajax({
        url: '/api/Paciente/',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Pacientes(data.map(e => {
                return {
                    id: e.id,
                    name: e.nome,
                };
            }));
        }
    });


    $.ajax({
        url: '/api/Consultorio',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Consultorios(data.map(e => {
                return {
                    id: e.id,
                    name: e.nome,
                };
            }));
        }
    });


    //Add New Item
    self.create = function (teste) {

        if (Agendamento.DataHoraMarcada() != "" || Agendamento.Medico() != "" || Agendamento.Consultorio() != "" || Agendamento.Paciente() != "") {
            var consultorio = ko.toJSON(Agendamento);
            $.ajax({
                url: '/api/HorarioAgenda/Insere',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: consultorio,
                success: function (data) {
                    self.Agendamentos(data.map(e => {
                        return {
                            Id: e.id,
                            DataHoraMarcada: e.dataHoraMarcada,
                            Medico: e.medico,
                            Consultorio: e.consultorio,
                            Paciente: e.paciente
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
            alert('Preenchimento de dados obrigatorio.');
        }
    }
    // Delete Agendamento details
    self.delete = function (Agendamento) {
        if (confirm('Tem certeza que deseja cancelar "' + Agendamento.Nome + '" ?')) {
            var id = Agendamento.Id;

            $.ajax({
                url: '/api/HorarioAgenda/Delete/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: id,
                success: function (data) {
                    self.Agendamentos.remove(Agendamento);
                    self.Agendamentos(data.map(e => {
                        return {
                            Id: e.id,
                            DataHoraMarcada: e.dataHoraMarcada,
                            Medico: e.medico,
                            Consultorio: e.consultorio,
                            Paciente: e.paciente
                        };
                    }));
                }
            }).fail(
                function (xhr, textStatus, err) {
                    alert(xhr.responseJSON.message);
                });
        }
    }

    // Edit Agendamento details
    self.edit = function (consultorio) {
        self.Agendamento(consultorio);
    }

    // Update Agendamento details
    self.update = function () {
        var Agendamento = self.Agendamento();

        $.ajax({
            url: '/api/HorarioAgenda/Update',
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Agendamento),
            success: function (data) {
                self.Agendamentos.removeAll();
                self.Agendamentos(data.map(e => {
                    return {
                        Id: e.id,
                        DataHoraMarcada: e.dataHoraMarcada,
                        Medico: e.medico,
                        Consultorio: e.consultorio,
                        Paciente: e.paciente
                    };
                }));
                self.Agendamento(null);

            }
        })
            .fail(
                function (xhr, textStatus, err) {
                    alert(err);
                });
    }

    // Reset Agendamento details
    self.reset = function () {
        self.Nome("");

    }

    // Cancel Agendamento details
    self.cancel = function () {
        self.Agendamento(null);
    }
}
var viewModel = new AgendamentoViewModel();
ko.applyBindings(viewModel);
