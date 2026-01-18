const viewBtn = document.getElementById("viewBtn");
const tableBox = document.getElementById("tableBox");
const tbody = document.getElementById("tbody");
const search = document.getElementById("search");
const cityFilter = document.getElementById("cityFilter");

const transactionBox = document.getElementById("transactionBox");
const transactionBody = document.getElementById("transactionBody");


const txnModal = document.getElementById("txnModal");
const txnTitle = document.getElementById("txnTitle");
const txnAmount = document.getElementById("txnAmount");

const createModal = document.getElementById("createModal");
const newName = document.getElementById("newName");
const newEmail = document.getElementById("newEmail");
const newCity = document.getElementById("newCity");

const balanceModal = document.getElementById("balanceModal");
const balanceText = document.getElementById("balanceText");


const deleteModal = document.getElementById("deleteModal");


let accountData = [];
let currentAccountId = null;
let txnType = null;


function generateBalance() {
  return Math.floor(Math.random() * (50000 - 10000 + 1)) + 10000;
}

function saveAndRender() {
  localStorage.setItem("accounts", JSON.stringify(accountData));
  renderTable(accountData);
  populateCities();
}


const stored = localStorage.getItem("accounts");
if (stored) {
  accountData = JSON.parse(stored);
  tableBox.classList.remove("hidden");
  renderTable(accountData);
  populateCities();
}


viewBtn.addEventListener("click", async () => {
  transactionBox.classList.add("hidden");
  tableBox.classList.remove("hidden");

  if (accountData.length > 0) {
    renderTable(accountData);
    populateCities();
    return;
  }

  const res = await fetch("https://mock-api-u9du.onrender.com/accounts");
  const data = await res.json();

  accountData = data.map(acc => ({
    ...acc,
    balance: generateBalance(),
    transactions: []
  }));

  saveAndRender();
});


function renderTable(data) {
  tbody.innerHTML = data.map(acc => `
    <tr class="${acc.balance < 5000 ? 'bg-red-50' : ''}">
      <td class="px-4 py-3">${acc.id}</td>
      <td class="px-4 py-3">${acc.name}</td>
      <td class="px-4 py-3">${acc.email}</td>
      <td class="px-4 py-3">${acc.address.city}</td>
      <td class="px-4 py-3 font-semibold">₹${acc.balance}</td>
      <td class="px-4 py-3 space-x-2">
        <button onclick="openTxnModal(${acc.id}, 'Deposit')"
          class="bg-blue-500 text-white px-2 py-1 rounded text-xs">Deposit</button>
        <button onclick="openTxnModal(${acc.id}, 'Withdraw')"
          class="bg-orange-500 text-white px-2 py-1 rounded text-xs">Withdraw</button>
      </td>
      <td class="px-4 py-3">
        <button onclick="openDeleteModal(${acc.id})"
          class="bg-red-600 text-white px-2 py-1 rounded text-xs">Delete</button>
      </td>
    </tr>
  `).join("");
}


search.addEventListener("input", () => {
  const text = search.value.toLowerCase();
  const filtered = accountData.filter(a =>
    a.name.toLowerCase().includes(text) ||
    a.email.toLowerCase().includes(text) ||
    a.address.city.toLowerCase().includes(text)
  );
  renderTable(filtered);
});




function populateCities() {
  const cities = [...new Set(accountData.map(a => a.address.city))];
  cityFilter.innerHTML = `<option value="">All Cities</option>`;
  cityFilter.innerHTML += cities.map(c =>
    `<option value="${c}">${c}</option>`
  ).join("");
}

cityFilter.addEventListener("change", () => {
  const city = cityFilter.value;
  const filtered = city
    ? accountData.filter(a => a.address.city === city)
    : accountData;
  renderTable(filtered);
});



function openTxnModal(id, type) {
  currentAccountId = id;
  txnType = type;
  txnTitle.innerText = `${type} Amount`;
  txnAmount.value = "";
  txnModal.classList.remove("hidden");
  txnModal.classList.add("flex");
}

function closeTxnModal() {
  txnModal.classList.add("hidden");
  txnModal.classList.remove("flex");
}

function confirmTxn() {
  const amount = Number(txnAmount.value);
  if (!amount || amount <= 0) return alert("Enter valid amount");

  const acc = accountData.find(a => a.id === currentAccountId);

  if (txnType === "Deposit") {
    acc.balance += amount;
  } else {
    if (acc.balance - amount < 5000) {
      alert("Minimum balance ₹5000 required. ₹200 penalty applied");
      acc.balance -= 200;
    } else {
      acc.balance -= amount;
    }
  }

  acc.transactions.push({
    type: txnType,
    amount,
    date: new Date().toLocaleString()
  });

  closeTxnModal();
  saveAndRender();
}

function createAccount() {
  createModal.classList.remove("hidden");
  createModal.classList.add("flex");

  newName.value = "";
  newEmail.value = "";
  newCity.value = "";
}

function closeCreateModal() {
  createModal.classList.add("hidden");
  createModal.classList.remove("flex");
}

function confirmCreateAccount() {
  const name = newName.value.trim();
  const email = newEmail.value.trim();
  const city = newCity.value.trim();

  if (!name || !email || !city) {
    alert("All fields are required");
    return;
  }

  accountData.push({
    id: Date.now(),
    name,
    email,
    address: { city },
    balance: generateBalance(),
    transactions: []
  });

  closeCreateModal();
  saveAndRender();
}



function openDeleteModal(id) {
  currentAccountId = id;
  deleteModal.classList.remove("hidden");
  deleteModal.classList.add("flex");
}

function closeDeleteModal() {
  deleteModal.classList.add("hidden");
  deleteModal.classList.remove("flex");
}

function confirmDelete() {
  accountData = accountData.filter(a => a.id !== currentAccountId);
  closeDeleteModal();
  saveAndRender();
}

// ===== SORT & TOTAL =====
function sortByBalance() {
  accountData.sort((a, b) => b.balance - a.balance);
  renderTable(accountData);
}

function totalBalance() {
  const total = accountData.reduce((sum, a) => sum + a.balance, 0);
  balanceText.innerText = `₹${total}`;
  balanceModal.classList.remove("hidden");
  balanceModal.classList.add("flex");
}

function closeBalanceModal() {
  balanceModal.classList.add("hidden");
  balanceModal.classList.remove("flex");
}


function showTransactions() {
  tableBox.classList.add("hidden");
  transactionBox.classList.remove("hidden");

  const allTx = [];
  accountData.forEach(acc => {
    acc.transactions.forEach(tx => {
      allTx.push({
        id: acc.id,
        name: acc.name,
        ...tx
      });
    });
  });

  if (allTx.length === 0) {
    transactionBody.innerHTML = `
      <tr>
        <td colspan="5" class="px-4 py-3 text-center text-gray-500">
          No transactions yet
        </td>
      </tr>`;
    return;
  }

  transactionBody.innerHTML = allTx.map(tx => `
    <tr>
      <td class="px-4 py-3">${tx.id}</td>
      <td class="px-4 py-3">${tx.name}</td>
      <td class="px-4 py-3 font-semibold ${tx.type === 'Deposit' ? 'text-green-600' : 'text-red-600'}">
        ${tx.type}
      </td>
      <td class="px-4 py-3">₹${tx.amount}</td>
      <td class="px-4 py-3">${tx.date}</td>
    </tr>
  `).join("");
}
