using System.Collections.Generic;
using Characters;
using UnityEngine;
using UnityEngine.Networking;

namespace Main
{
    public class SolarSystemNetworkManager : NetworkManager
    {
        [SerializeField] private string playerName;
        [SerializeField] private InputPlayerName _inputPlayerName;
        private Dictionary<int,ShipController> _players = new Dictionary<int, ShipController>();

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            var spawnTransform = GetStartPosition();

            var player = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
            var shipContr = player.GetComponent<ShipController>();
            _players.Add(conn.connectionId, shipContr);
            //shipContr.PlayerName = playerName;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler(577, ReceiveLogin);
        }
        
        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);
            _inputPlayerName.gameObject.SetActive(true);
            _inputPlayerName.ButtonOk.onClick.AddListener(() =>
            {
                var messLogin = new MessLogin {Login = _inputPlayerName.InputName.text};
                conn.Send(577, messLogin);
                _inputPlayerName.ButtonOk.onClick.RemoveAllListeners();
                _inputPlayerName.gameObject.SetActive(false);
            });
        }
        
        public void ReceiveLogin(NetworkMessage networkMessage)
        {
            _players[networkMessage.conn.connectionId].PlayerName = networkMessage.reader.ReadString();
        }
    }
}
