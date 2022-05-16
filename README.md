# recorte-horario-semanal-ifro-jipa

## Sobre

Este projeto gera tiras de horários para turmas específicas em imagem a partir de um horário geral em PDF.

## Dependencias

- [dotnet](https://dotnet.microsoft.com/en-us/)

## Playground

### Adquirindo o Código

```sh
git clone https://github.com/guesant/recorte-horario-semanal-ifro-jipa.git
cd recorte-horario-semanal-ifro-jipa
```

### Exemplos de Uso

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

- O arquivo PDF com o Horário Geral se chame: `horario-geral.pdf`;
- O _payload_ seja o da turma "2ªA Informática" : [`../samples/payload-inf-2a.json`](./samples/payload-inf-2a.json);
- O arquivo final se chamará: `horario-recortado-2a.png`;

```sh
dotnet run horario-geral.pdf ../samples/payload-inf-2a.json horario-recortado-2a.png
```

## Author

- Gabriel R. Antunes - <https://github.com/guesant>

## License

- GPL-3.0 (você deve ter recebido uma cópia no arquivo [LICENSE](./LICENSE)).
