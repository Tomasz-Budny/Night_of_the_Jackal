using Assets.Scripts.Architecture;
using UnityEngine;

namespace Assets.Scripts
{
    internal class StickyNoteManager : SingletonInstance<StickyNoteManager>
    {
        public int maxStickyNotes = 8;
        public GameObject stickyNotePrefab;
        public Transform stickyNotePosition;
        public Transform stickyNoteParent;

        private int _stickyNoteCount = 0;

        public void Start()
        {
            CreateStickyNote();
        }

        public void CreateStickyNote()
        {
            if (_stickyNoteCount > maxStickyNotes) return;

            var cratedStickyNote = Instantiate(stickyNotePrefab, stickyNotePosition.position, Quaternion.identity, stickyNoteParent);
            cratedStickyNote.transform.SetAsFirstSibling();
            _stickyNoteCount++;
        }

    }
}
