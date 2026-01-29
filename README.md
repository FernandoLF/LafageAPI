# LafageAPI 🚀

![.NET](https://img.shields.io/badge/.NET-7-blue)
![C#](https://img.shields.io/badge/C%23-blueviolet)
![SQL Server](https://img.shields.io/badge/SQL_Server-green)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

API REST para la **gestión de ventas**, incluyendo Personas, Clientes, Asesores Comerciales, Líneas de Producto, Productos y Pedidos.  
Incluye un **frontend sencillo en HTML/JS** para probar la integración.

---

## 🚀 Levantar la API

### 1. Clonar el repositorio
```bash
git clone https://github.com/FernandoLF/LafageAPI.git
cd LafageAPI
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Ejecutar la API
```bash
dotnet run --project src/Lafage.Sales.Api
```

La API estará disponible en:  
- HTTP: [http://localhost:5224/api](http://localhost:5224/api)  
- HTTPS: [https://localhost:7224/api](https://localhost:7224/api)

---

## 🗄️ Base de datos

En la carpeta `ScriptDB/` encontrarás:
- `schema.sql` → Tablas  
- `procedures.sql` → Stored Procedures  
- `triggers.sql` → Triggers

Ejecuta los scripts en **SQL Server** para crear la base de datos:
```bash
sqlcmd -S localhost -d LafageDB -i ScriptDB/schema.sql
sqlcmd -S localhost -d LafageDB -i ScriptDB/procedures.sql
sqlcmd -S localhost -d LafageDB -i ScriptDB/triggers.sql
```

---

## 🌐 Frontend

El frontend se encuentra en `FrontEnd/` y permite probar la API mediante formularios y llamadas asíncronas.

Pasos para usarlo:
1. Asegúrate de que la API esté corriendo en [http://localhost:5224](http://localhost:5224).  
2. Abre `FrontEnd/index.html` en tu navegador.  
3. Usa los formularios y botones para interactuar con la API.

---

## 📌 Endpoints principales

| Entidad               | Endpoint                         | Acciones principales           |
|-----------------------|---------------------------------|-------------------------------|
| Personas              | `/api/persona`                  | Crear, consultar, desactivar  |
| Clientes              | `/api/cliente`                  | Crear, consultar              |
| Asesores Comerciales  | `/api/asesorcomercial`          | Crear, consultar              |
| Líneas de Producto    | `/api/lineaproducto`            | Crear, consultar              |
| Productos             | `/api/producto`                 | Crear, consultar              |
| Pedidos               | `/api/pedido/simple`            | Crear pedido simple           |
|                       | `/api/pedido/multiple`          | Crear pedido múltiple         |

---

## ✅ Funcionalidades del Frontend

- **Personas**: Crear, consultar, desactivar  
- **Clientes**: Crear, consultar  
- **Productos**: Crear, consultar  
- **Pedidos**: Crear pedido simple  

Todas las acciones se realizan mediante formularios HTML y llamadas **asíncronas (fetch)**.

---

## 📂 Tecnologías utilizadas
- **C# .NET 7**  
- **SQL Server**  
- **HTML / JavaScript**

---

## 👨‍💻 Autor

Proyecto desarrollado por **Fernando López**.

---

## 📄 Licencia

Este proyecto está bajo la licencia **MIT**.

