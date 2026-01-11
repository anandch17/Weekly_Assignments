const plans = [
    { name: "Health", base: 3000 },
    { name: "Life", base: 5000 },
    { name: "Vehicle", base: 2000 }
];

const customers = [];

const plansDiv = document.getElementById("plans");

plans.forEach(p => {
    const d = document.createElement("div");
    d.className = "bg-white p-3 border";
    d.innerHTML = `
        <p><b>${p.name}</b></p>
        <p>Base: ₹${p.base}</p>
    `;
    plansDiv.appendChild(d);
});

function calcPremium(age, policy, cover) {
    let base = policy === "Health" ? 3000 :
               policy === "Life" ? 5000 : 2000;

    let premium = base + (cover - 1) * 500;
    if (age > 45) premium += premium * 0.2;

    return Math.round(premium);
}

document.getElementById("form").addEventListener("submit", e => {
    e.preventDefault();

    const name = document.getElementById("name").value.trim();
    const age = Number(document.getElementById("age").value);
    const policy = document.getElementById("policy").value;
    const cover = Number(document.getElementById("cover").value);

    if (!name || !age || !policy) return;

    const premium = calcPremium(age, policy, cover);

    customers.push({ name, age, policy, cover, premium });
    render();
    e.target.reset();
});

function render() {
    const filter = document.getElementById("filter").value;
    const search = document.getElementById("search").value.toLowerCase();

    let list = customers.filter(c =>
        (!filter || c.policy === filter) &&
        c.name.toLowerCase().includes(search)
    );

    const table = document.getElementById("table");
    table.innerHTML = "";

    list.forEach(c => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td class="border p-2">${c.name}</td>
            <td class="border p-2">${c.age}</td>
            <td class="border p-2">${c.policy}</td>
            <td class="border p-2">${c.cover}L</td>
            <td class="border p-2">₹${c.premium}</td>
        `;
        table.appendChild(tr);
    });

    document.getElementById("count").innerText = customers.length;
    document.getElementById("total").innerText =
        customers.reduce((t, c) => t + c.premium, 0);
}

document.getElementById("filter").addEventListener("change", render);
document.getElementById("search").addEventListener("input", render);
