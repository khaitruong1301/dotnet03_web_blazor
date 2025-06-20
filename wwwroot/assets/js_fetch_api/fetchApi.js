
//fetch: gửi request đến web api trực tiếp từ browser

window.getAllProduct = async function () {
    let res = await fetch("https://svcy.myclass.vn/api/ProductApi/getall");
    let jsonProduct = await res.json();
    let stringHTML = '';
    for(let prod of jsonProduct){
        stringHTML  += `
            <tr>
                <td>${prod.id}</td>
                <td>${prod.name}</td>
                <td><img width="50" src="${prod.img}" alt="..." /></td>
                <td>${prod.price}</td>
            </tr>
        `
    }
    document.querySelector('#tbodyContent').innerHTML = stringHTML;

}

window.luuToken = async function (token) {
    console.log(token);
    localStorage.setItem('accessToken',token);
}


// getAllProduct();