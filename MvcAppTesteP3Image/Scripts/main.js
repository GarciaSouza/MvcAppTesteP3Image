
function compareCategorias(a, b) {
    if (a.Ordem < b.Ordem)
        return -1;
    else if (a.Ordem > b.Ordem)
        return 1;
    else
        return 0;
}

function getFormGroupByCampo(campo) {
    switch (campo.Tipo) {
        case 'select':
            var div = "<div class='form-group'><label for='form_campo_" + campo.Id + "'>" + campo.Descricao + "</label><select class='form-control' id='form_campo_" + campo.Id + "'>";
            campo.Lista.forEach(function (l, i) {
                div += "<option>" + l + "</option>";
            });
            div += "</select></div>";
            return div;
        case 'text':
        default:
            return "<div class='form-group'><label for='form_campo_" + campo.Id + "'>" + campo.Descricao + "</label><input type='text' class='form-control' id='form_campo_" + campo.Id + "' /></div>";
    }
}
