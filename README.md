# recorte-horario-semanal-ifro-jipa

## Sobre

Este projeto gera tiras de horários para turmas específicas em imagem a partir de um horário geral em PDF.

## Playground

### Adquirindo o Código

```sh
git clone https://github.com/guesant/recorte-horario-semanal-ifro-jipa.git
cd recorte-horario-semanal-ifro-jipa
```

### Exemplos de Uso

#### Uso com o Docker (recomendado)

Construa a imagem do projeto com:

```sh
cd RecorteHorarioSemanalIFROJipa
docker build -t recorte-horario-semanal -f Dockerfile .
cd ..
```

Agora, para usar a CLI:

```sh
docker run -it --rm -v $(pwd):/appdata -w /appdata recorte-horario-semanal horario-geral.pdf samples/payload-inf-2a.json horario-final.png
```

#### Uso sem o Docker

Primeiro de tudo, entre na pasta do projeto C#:

```sh
cd RecorteHorarioSemanalIFROJipa
```

Uso da CLI:

```sh
dotnet run <horario-geral.pdf> <payload.json> <horario-recortado.png>
```

---

Vamos supor que:

- O arquivo PDF com o Horário Geral possui o nome `horario-geral.pdf`;
- O _payload_ seja o da turma "2ªA Informática": [`./samples/payload-inf-2a.json`](./samples/payload-inf-2a.json);
- O arquivo final se chamará `horario-recortado-2a.png`;

```sh
dotnet run horario-geral.pdf ../samples/payload-inf-2a.json horario-recortado-2a.png
```

https://user-images.githubusercontent.com/43099880/168505658-5a0ace1c-e04f-4f13-bd8a-160dc318cf24.mp4

## Dependencias

- `dotnet` - <https://dotnet.microsoft.com/en-us/>

- `libvips` - <https://www.libvips.org/install.html>

## Author

- Gabriel R. Antunes - <https://github.com/guesant>

## License

- GPL-3.0 (você deve ter recebido uma cópia no arquivo [LICENSE](./LICENSE)).
