// Выбор элемента https://stackoverflow.com/a/75765576/25604142

/** Ключ элемента имени выбранного гвоздя в local storage */
const SelectedNailNameKey = "SelectedNailName";

/**
 *Выбрать гвоздь и записать его ИД в память
 * @param {Guid} id
 * @param {string} name
 * @param {htmlTrTag} row
 */
async function SelectNail(id, name, row) {
    let form = new FormData();
    form.append('id', id);

    await fetch('/Home/SelectNail', {
        method: 'POST',
        body: form,
    });

    DeHighlight();
    row.style.backgroundColor = 'white';
    row.style.color = 'red';
    row.classList.toggle("selectedRow");

    localStorage.setItem(SelectedNailNameKey, name);

    document.getElementById('EditButton').disabled = false;
    document.getElementById('DeleteButton').disabled = false;
}

/** Убрать выделение */
function DeHighlight() {
    let table = document.getElementById("MainTable");
    let rows = table.rows;
    for (let i = 0; i < rows.length; i++) {
        rows[i].style.backgroundColor = "transparent";
        rows[i].style.color = 'black';
    }
}

/** Подтвердить удаление гвоздя и удалить его */
async function ConfirmDeleteNail(id) {
    let nailName = localStorage.getItem(SelectedNailNameKey);
    if (nailName != null) {
        if (confirm(`Точно удалить гвоздь "${nailName}"? Это действие необратимо`)) {
            await fetch('/Home/DeleteNail', {
                method: 'DELETE'
            });
            window.location.reload();
        }
    }
}

/** Очистить название выбранного гвоздя из памяти */
function ClearSelectedNail() {
    localStorage.removeItem(SelectedNailNameKey);

    document.getElementById('EditButton').disabled = true;
    document.getElementById('DeleteButton').disabled = true;
}
