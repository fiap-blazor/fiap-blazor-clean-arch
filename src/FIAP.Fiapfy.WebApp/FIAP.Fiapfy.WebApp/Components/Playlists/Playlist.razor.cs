using FIAP.Fiapfy.Aplicacao.DTOs;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;
using FIAP.Fiapfy.Dominio.Modelos;
using Microsoft.AspNetCore.Components;

namespace FIAP.Fiapfy.WebApp.Components.Playlists
{
    public partial class Playlist
    {
        [Parameter]
        public int Id { get; set; }

        private PlaylistResponse? playlist;
        private PaginacaoConsulta<MusicaResponse> resultadosBusca = new();
        private bool mostrarModal = false;
        private string termoBusca = string.Empty;
        private string? usuarioAtualId;
        private bool ehDonoPlaylist = false;
        private bool buscaRealizada = false;
        private int resultadosPg = 1;
        private int resultadosQt = 10;
        private string playlistCriadoPor = "Usuário";

        private string PlaylistCountText => playlist is null
            ? "0 músicas"
            : $"{playlist.PlaylistMusicas.Count} {(playlist.PlaylistMusicas.Count == 1 ? "música" : "músicas")}";

        protected override async Task OnInitializedAsync()
        {
            await CarregarUsuarioEPlaylist();
        }

        private async Task CarregarUsuarioEPlaylist()
        {
            try
            {
                var estaAutenticado = await UsuarioAutenticadoServico.EstaAutenticadoAsync();
                usuarioAtualId = estaAutenticado ? await UsuarioAutenticadoServico.ObterIdUsuarioAsync() : null;
            }
            catch
            {
                usuarioAtualId = null;
            }

            await CarregarPlaylist();

            ehDonoPlaylist = playlist != null
                             && !string.IsNullOrEmpty(usuarioAtualId)
                             && string.Equals(playlist.UsuarioId, usuarioAtualId, StringComparison.Ordinal);

            if (playlist != null)
            {
                playlistCriadoPor = await ObterNomeCriadorAsync(playlist.UsuarioId, ehDonoPlaylist);
            }
        }

        private async Task<string> ObterNomeCriadorAsync(string usuarioId, bool ehDono)
        {
            if (ehDono) return "Você";

            try
            {
                var user = await UserManager.FindByIdAsync(usuarioId);
                return user?.UserName ?? user?.Email ?? "Usuário";
            }
            catch
            {
                return "Usuário";
            }
        }

        private async Task CarregarPlaylist()
            => playlist = await PlaylistsAppServico.ObterPorIdAsync(Id);

        private async Task RealizarBusca()
        {
            if (string.IsNullOrWhiteSpace(termoBusca))
            {
                buscaRealizada = false;
                resultadosBusca = new();
                return;
            }

            var request = new MusicaListarRequest
            {
                Nome = termoBusca,
                Pg = resultadosPg,
                Qt = resultadosQt
            };

            resultadosBusca = await MusicasAppServico.ListarAsync(request);
            buscaRealizada = true;
        }

        private async Task OnBuscaPageChanged(int pg)
        {
            resultadosPg = pg;
            await RealizarBusca();
        }

        private void AbrirModalAdicionarMusica()
        {
            if (!ehDonoPlaylist) return;

            termoBusca = string.Empty;
            buscaRealizada = false;
            mostrarModal = true;
        }

        private void FecharModal()
        {
            mostrarModal = false;
            termoBusca = string.Empty;
            buscaRealizada = false;
        }

        private async Task AdicionarMusica(MusicaResponse musica)
        {
            if (!ehDonoPlaylist || playlist == null) return;

            try
            {
                await PlaylistsAppServico.AdicionarMusicaAsync(playlist.Id, musica.Id);
                var playlistMusica = new PlaylistMusicaResponse(DateTime.Now, musica);
                playlist.PlaylistMusicas.Add(playlistMusica);
            }
            catch
            {

            }
        }

        private async Task RemoverMusica(int musicaId)
        {
            if (!ehDonoPlaylist || playlist == null) return;

            try
            {
                await PlaylistsAppServico.RemoverMusicaAsync(playlist.Id, musicaId);
                var musica = playlist.PlaylistMusicas.FirstOrDefault(m => m.Musica.Id == musicaId);
                if (musica != null) playlist.PlaylistMusicas.Remove(musica);
            }
            catch
            {

            }
        }
    }
}