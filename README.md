# 🏢 MultiTenantWPFApp

Aplicación WPF multi-tenant para gestionar múltiples empresas desde una única interfaz.

## 🎯 Características

✅ **Gestión Multi-Empresa**: Cambia entre empresas sin cerrar la aplicación  
✅ **Lógica Compartida**: 90% del código es común entre empresas  
✅ **Temas Dinámicos**: Colores y estilos personalizados por empresa  
✅ **Escalable**: Fácil agregar nuevas empresas  
✅ **Arquitectura Limpia**: MVVM + Dependency Injection  

## 📋 Requisitos

- Visual Studio 2025 o posterior
- .NET 10.0 o superior
- Windows 10/11

## 🚀 Cómo ejecutar

1. Clona el repositorio:
```bash
git clone https://github.com/Miguelak08/MultiTenantWPFApp.git
cd MultiTenantWPFApp
```

2. Abre el proyecto en Visual Studio

3. Restaura los paquetes NuGet:
```bash
dotnet restore
```

4. Compila y ejecuta:
```bash
dotnet run
```

## 📁 Estructura del Proyecto

```
MultiTenantWPFApp/
├── Helpers/                    # Clases auxiliares (RelayCommand, ViewModelBase)
├── Models/                     # Modelos de datos
├── Services/
│   ├── Interfaces/            # Contratos de servicios
│   └── Implementations/        # Implementaciones de servicios
├── ViewModels/                # ViewModels MVVM
├── Views/                     # Ventanas XAML
├── Themes/                    # ResourceDictionaries (temas)
├── Resources/                 # Imágenes y recursos
├── App.xaml                   # Configuración de la aplicación
└── README.md                  # Este archivo
```

## 🎨 Empresas Disponibles

1. **Empresa A** - Color azul (#0066CC)
   - Features: Reports, Analytics, Inventory

2. **Empresa B** - Color verde (#009900)
   - Features: Reports, CRM

## 🔄 Cómo cambiar de empresa

1. Click en el botón "🔄 Cambiar Empresa" en la barra superior
2. Selecciona la empresa que deseas
3. La interfaz se actualiza automáticamente sin cerrar la aplicación

## 🛠️ Personalización

Para agregar una nueva empresa, edita `Services/Implementations/TenantConfigurationService.cs`:

```csharp
{ 3, new TenantConfiguration
{
    TenantId = 3,
    TenantName = "Empresa C",
    PrimaryColor = "#FFFF6600",
    SecondaryColor = "#FFCC3300",
    Logo = "pack://application:,,,/Resources/LogoC.png",
    EnabledFeatures = new List<string> { "Reports", "Custom Feature" }
}}
```

## 🤝 Contribuir

Las contribuciones son bienvenidas. Por favor:
1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo licencia MIT.

## ✉️ Contacto

**Miguelak08** - [@Miguelak08](https://github.com/Miguelak08)

---

**Hecho con ❤️ usando WPF y .NET 10