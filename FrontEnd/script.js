const API_URL = "http://localhost:5224/api";

// Personas
async function crearPersona(e) {
  e.preventDefault();
  const persona = {
    nombre: document.getElementById("nombre").value,
    apellido: document.getElementById("apellido").value,
    direccion: document.getElementById("direccion").value,
    telefono: document.getElementById("telefono").value,
    email: document.getElementById("email").value,
    numeroIdentificacion: document.getElementById("numeroIdentificacion").value
  };
  const res = await fetch(`${API_URL}/persona`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(persona)
  });
  document.getElementById("personas").innerText = await res.text();
}

async function consultarPersonas() {
  const res = await fetch(`${API_URL}/persona`);
  document.getElementById("personas").innerText = JSON.stringify(await res.json(), null, 2);
}

async function desactivarPersona() {
  const res = await fetch(`${API_URL}/persona/1/desactivar`, { method: "PUT" });
  document.getElementById("personas").innerText = await res.text();
}

// Clientes
async function crearCliente(e) {
  e.preventDefault();
  const cliente = {
    idPersona: document.getElementById("idPersonaCliente").value,
    nit: document.getElementById("nitCliente").value
  };
  const res = await fetch(`${API_URL}/cliente`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(cliente)
  });
  document.getElementById("clientes").innerText = await res.text();
}

async function consultarClientes() {
  const res = await fetch(`${API_URL}/cliente`);
  document.getElementById("clientes").innerText = JSON.stringify(await res.json(), null, 2);
}

// Productos
async function crearProducto(e) {
  e.preventDefault();
  const producto = {
    idLineaProducto: document.getElementById("idLineaProducto").value,
    descripcion: document.getElementById("descripcionProducto").value,
    stock: document.getElementById("stockProducto").value,
    fechaProduccion: document.getElementById("fechaProduccion").value,
    precio: document.getElementById("precioProducto").value
  };
  const res = await fetch(`${API_URL}/producto`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(producto)
  });
  document.getElementById("productos").innerText = await res.text();
}

async function consultarProductos() {
  const res = await fetch(`${API_URL}/producto`);
  document.getElementById("productos").innerText = JSON.stringify(await res.json(), null, 2);
}

// Pedido simple
async function crearPedido(e) {
  e.preventDefault();
  const pedido = {
    idCliente: document.getElementById("idClientePedido").value,
    idVendedor: document.getElementById("idVendedorPedido").value,
    idProducto: document.getElementById("idProductoPedido").value,
    cantidad: document.getElementById("cantidadPedido").value,
    precioUnitario: document.getElementById("precioUnitarioPedido").value,
    descuento: document.getElementById("descuentoPedido").value
  };
  const res = await fetch(`${API_URL}/pedido/simple`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(pedido)
  });
  document.getElementById("pedido").innerText = await res.text();
}