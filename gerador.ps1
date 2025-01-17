param (
    [string]$className,
    [string]$properties,
    [string]$insertDto,
    [string]$updateDto,
    [string]$readDto
)
$baseProjectName = "PopFake"
# Caminho da pasta do modelo
$modelsPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Models"
$dtosPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Data\Dtos\$className" + "Dtos"
$profilesPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Data\Dtos\AutoMapperProfiles"
$dataContextPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Data\DataContext.cs"
$interfaceRepositoryPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Repository\Interfaces\"
$repositoryPath ="D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Repository\Repositorys"
$interfaceServicesPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Services\Interfaces"
$servicePath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Services\Services"
$controllerPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Web\Controllers"
$programCsPath = "D:\Projetos\Particular\ASPNet\$baseProjectName\$baseProjectName.Web\Program.cs"

# Verifica se a pasta existe, se não, cria a pasta
if (-not (Test-Path -Path $modelsPath)) {
    New-Item -ItemType Directory -Path $modelsPath
}

# Define o conteúdo base do arquivo com o namespace e as usings
$fileContent = @"
using $baseProjectName.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace $baseProjectName.Models;

public class $className : BaseEntity 
{
$properties
}
"@

# Nome do arquivo
$fileName = "$modelsPath\$className.cs"

# Cria o arquivo com o conteúdo gerado
New-Item -Path $fileName -ItemType File -Force
Set-Content -Path $fileName -Value $fileContent

Write-Host "Classe $className criada com sucesso em $modelsPath!"

# Verifica se a pasta existe, se não, cria a pasta
if (-not (Test-Path -Path $dtosPath)) {
    New-Item -ItemType Directory -Path $dtosPath
}

# Define o conteúdo base dos arquivos DTO
$insertDtoContent = @"
using System.ComponentModel.DataAnnotations;

namespace $baseProjectName.Data.Dtos;

public class Insert${className}Dto : BaseDto
{
    $insertDto
}
"@

$updateDtoContent = @"
using System.ComponentModel.DataAnnotations;

namespace $baseProjectName.Data.Dtos;

public class Update${className}Dto : BaseDto
{
    $updateDto
}
"@

$readDtoContent = @"
using System.ComponentModel.DataAnnotations;

namespace $baseProjectName.Data.Dtos;

public class Read${className}Dto : BaseDto
{
    $readDto
}
"@



# Nome dos arquivos DTO
$insertDtoFileName = "$dtosPath\Insert${className}Dto.cs"
$updateDtoFileName = "$dtosPath\Update${className}Dto.cs"
$readDtoFileName = "$dtosPath\Read${className}Dto.cs"

# Cria os arquivos DTO com o conteúdo gerado
New-Item -Path $insertDtoFileName -ItemType File -Force
Set-Content -Path $insertDtoFileName -Value $insertDtoContent

New-Item -Path $updateDtoFileName -ItemType File -Force
Set-Content -Path $updateDtoFileName -Value $updateDtoContent

New-Item -Path $readDtoFileName -ItemType File -Force
Set-Content -Path $readDtoFileName -Value $readDtoContent

Write-Host "DTOs criados com sucesso em $dtosPath!"

$profileContent = @"
using AutoMapper;
using $baseProjectName.Models;

namespace $baseProjectName.Data.Dtos.AutoMapperProfiles;

public class ${className}Profile : Profile
{
    public ${className}Profile()
    {
        CreateMap<${className}, Insert${className}Dto>().ReverseMap();
        CreateMap<${className}, Read${className}Dto>().ReverseMap();
        CreateMap<${className}, Update${className}Dto>().ReverseMap();
    }

}
"@

$profileFileName = "$profilesPath\${className}Profile.cs"

# Cria o arquivo de perfil do AutoMapper
New-Item -Path $profileFileName -ItemType File -Force
Set-Content -Path $profileFileName -Value $profileContent

Write-Host "Perfil do AutoMapper criado com sucesso em $profilesPath!"


# Verifica se o arquivo DataContext existe
if (Test-Path -Path $dataContextPath) {
    # Adiciona a nova linha com o DbSet ao final do bloco de propriedades (antes do construtor)
    $dbSetLine = "    public DbSet<$className> ${className}s { get; set; }"

    # Lê o conteúdo do DataContext
    $dataContextContent = Get-Content -Path $dataContextPath

    # Verifica se o DbSet já existe, para evitar duplicações
    if ($dataContextContent -notcontains $dbSetLine) {
        # Encontra o índice da linha onde o construtor começa
        $constructorIndex = ($dataContextContent | Select-String -Pattern 'public DataContext').LineNumber - 1

        # Garante que o DbSet seja adicionado antes do construtor
        $beforeConstructor = $dataContextContent[0..($constructorIndex - 1)] # Tudo até a linha antes do construtor
        $afterConstructor = $dataContextContent[$constructorIndex..($dataContextContent.Length - 1)] # Do construtor em diante

        # Concatena o novo conteúdo com o DbSet adicionado antes do construtor
        $newContent = $beforeConstructor + $dbSetLine + $afterConstructor
        
        # Atualiza o arquivo DataContext.cs com o novo conteúdo
        Set-Content -Path $dataContextPath -Value $newContent

        Write-Host "DbSet<$className> adicionado com sucesso no DataContext."
    } else {
        Write-Host "DbSet<$className> já existe no DataContext, não foi necessário adicionar."
    }
} else {
    Write-Host "Arquivo DataContext.cs não encontrado em $dataContextPath."
}

# Verifica se o arquivo de interface do repositório existe

$interfaceRepositoryContent = @"

using $baseProjectName.Models;
using $baseProjectName.Repository.GenericRepository;

namespace $baseProjectName.Repository.Interfaces;

public interface I${className}Repository : IGenericRepository<$className>
{

}
"@
$interfaceRepositoryFileName = "$interfaceRepositoryPath\I${className}Repository.cs"

# Cria o arquivo de interface do repositório
New-Item -Path $interfaceRepositoryFileName -ItemType File -Force
Set-Content -Path $interfaceRepositoryFileName -Value $interfaceRepositoryContent

Write-Host "Interface do repositório criada com sucesso em $interfaceRepositoryPath!"


$repositoryPathContent = @"
using $baseProjectName.Data;
using $baseProjectName.Models;
using $baseProjectName.Repository.GenericRepository;
using $baseProjectName.Repository.Interfaces;

namespace $baseProjectName.Repository.Repositorys;

public class ${className}Repository : GenericRepository<${className}>, I${className}Repository
{
    public ${className}Repository(DataContext context) : base(context)
    {
    }
}
"@

$repositoryPathFileName = "$repositoryPath\${className}Repository.cs"

# Cria o arquivo de repositório
New-Item -Path $repositoryPathFileName -ItemType File -Force
Set-Content -Path $repositoryPathFileName -Value $repositoryPathContent

Write-Host "Repositório criado com sucesso em $repositoryPath!"

$interfaceServicesContent = @"
using $baseProjectName.Models;
using $baseProjectName.Services.GenericService;

namespace $baseProjectName.Services.Interfaces
{
    public interface I${className}Service : IGenericService<${className}>
    {
 
    }
}
"@

$interfaceServicesFileName = "$interfaceServicesPath\I${className}Service.cs"

# Cria o arquivo de interface do serviço
New-Item -Path $interfaceServicesFileName -ItemType File -Force
Set-Content -Path $interfaceServicesFileName -Value $interfaceServicesContent

Write-Host "Interface do serviço criada com sucesso em $interfaceServicesPath!"



# Usando isso no conteúdo do arquivo
$serviceContent = @"
using $baseProjectName.Models;
using $baseProjectName.Repository.Interfaces;
using $baseProjectName.Services.GenericService;
using $baseProjectName.Services.Interfaces;

namespace $baseProjectName.Services
{
    public class ${className}Service : GenericService<${className}>, I${className}Service
    {
        private readonly I${className}Repository _${className.ToLower()}Repository;

        public ${className}Service(I${className}Repository ${className.ToLower()}Repository) : base(${className.ToLower()}Repository)
        {
            _${className.ToLower()}Repository = ${className.ToLower()}Repository;
        }
    }
}
"@


$serviceFileName = "$servicePath\${className}Service.cs"

# Cria o arquivo de serviço
New-Item -Path $serviceFileName -ItemType File -Force
Set-Content -Path $serviceFileName -Value $serviceContent

Write-Host "Serviço criado com sucesso em $servicePath!"

$controllerContent = @"
using AutoMapper;
using $baseProjectName.Models;
using $baseProjectName.Repository.Interfaces;
using $baseProjectName.Web.Controllers.GenericController;
using $baseProjectName.Data.Dtos;
using $baseProjectName.Services.Interfaces;

namespace $baseProjectName.Web.Controllers;
public class ${className}QueryParams
{
    public int Id { get; set; }
}
public class ${className}Controller : GenericController<${className}, Insert${className}Dto, Read${className}Dto, Update${className}Dto, ${className}QueryParams>
{
    public ${className}Controller(I${className}Service service, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(service, mapper, httpContextAccessor)
    {

    }

}
"@

$controllerFileName = "$controllerPath\${className}Controller.cs"

# Cria o arquivo de controller
New-Item -Path $controllerFileName -ItemType File -Force
Set-Content -Path $controllerFileName -Value $controllerContent

Write-Host "Controller criado com sucesso em $controllerPath!"




# Verifica se o arquivo Program.cs existe
if (Test-Path -Path $programCsPath) {
    # Adiciona a nova linha para o AddScoped no local apropriado
    $serviceLine = "builder.Services.AddScoped<I${className}Service, ${className}Service>();"
    $repositoryLine = "builder.Services.AddScoped<I${className}Repository, ${className}Repository>();"
    
    # Lê o conteúdo do Program.cs
    $programCsContent = Get-Content -Path $programCsPath
    
    # Verifica se as linhas já existem, para evitar duplicações
    if (($programCsContent -notcontains $serviceLine) -and ($programCsContent -notcontains $repositoryLine)) {
        # Localiza o ponto onde os services são adicionados (pode usar um comentário específico ou um local fixo)
        $injectionIndex = ($programCsContent | Select-String -Pattern '//dependency injection inserir novos services e repositorys aqui abaixo').LineNumber
        
        # Adiciona as novas linhas logo abaixo do comentário
        $newContent = $programCsContent[0..$injectionIndex] + $serviceLine + $repositoryLine + $programCsContent[($injectionIndex + 1)..($programCsContent.Length - 1)]
        
        # Atualiza o arquivo Program.cs
        Set-Content -Path $programCsPath -Value $newContent
        
        Write-Host "Services e repositories adicionados com sucesso no Program.cs."
    } else {
        Write-Host "As linhas já existem no Program.cs, não foi necessário adicionar."
    }
} else {
    Write-Host "Arquivo Program.cs não encontrado em $programCsPath."
}