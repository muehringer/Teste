Vue.component('LeitorRSSComponent', {
    template: `<main role="main" style="background-color:darkgray !important; color:white !important">

        <div class="jumbotron" style="background-color: dimgray !important; color: white !important; text-align:center; margin-top: 10px !important; margin-bottom: 80px !important">
            <div class="container">
                <h6>Leitor RSS</h6>
                <h2>Informações Gerais</h2>
                <br />
                <br />
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-12">Clique para gerar as informações</div>
                <div class="col-md-12"><router-link to="/" @click.native="gerarinfo" class="btn btn-secondary">GERAR</router-link></div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">Conteúdo dos dez últimos tópicos</div>
                <div class="col-md-3" v-for="conteudo in conteudos" style="color: darkslategray !important; padding-bottom: 5px !important; padding-left: 5px !important">
                    <div style="background-color: white !important; ">
                        <div class="card mb-4 shadow-sm">
                            <div class="card-header">
                                <span>{{ conteudo.title }}</span>
                            </div>
                            <div class="card-body">
                                <span>{{ conteudo.description }}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">Dez principais palavras abordadas e a quantidade de vezes que elas aparecem</div>
                <div class="col-md-3" v-for="palavra in palavras" style="color: darkslategray !important; padding-bottom: 5px !important; padding-left: 5px !important">
                    <div style="background-color: white !important; ">
                        <div class="card mb-4 shadow-sm">
                            <div class="card-header">
                                <span>Palavras: {{ palavra.palavra }}</span>
                            </div>
                            <div class="card-body">
                                <span>Quantidade de vezes: {{ palavra.quantidadeVezes }}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">Quantidade de palavras por tópico</div>
                <div class="col-md-3" v-for="qtdepalavra in qtdepalavrastopico" style="color: darkslategray !important; padding-bottom: 5px !important; padding-left: 5px !important">
                    <div style="background-color: white !important; ">
                        <div class="card mb-4 shadow-sm">
                            <div class="card-header">
                                <span>Palavras por Tópico: {{ qtdepalavra }}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <hr>

        </div>

    </main>`,
    data: function () {
        return {
            conteudos: null,
            palavras: null,
            qtdepalavrastopico: null,
            count: 0,
        }
    },
    mounted: function () {
    },
    methods: {
        gerarinfo: function (event) {
            axios.get('http://localhost:10234/feed/get-info-general')
                .then(response => {
                    this.conteudos = response.data.feedsDezTopicos;
                    this.palavras = response.data.dezPalavrasAbordadasQtdeVezes;
                    this.qtdepalavrastopico = response.data.qtdePalavrasPorTopico;
            })
            .catch(error => {
                console.log(error)
                this.errored = true
            })
        }
    }
})

