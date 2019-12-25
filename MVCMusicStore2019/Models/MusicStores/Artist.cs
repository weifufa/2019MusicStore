using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStores
{
    /// <summary>
    /// 艺术家、歌手类
    /// </summary>
    public class Artist:IEntity
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }//简介
        public Artist()
        {
            this.Id = Guid.NewGuid();
        }
        public Artist(Artist artist)
        {
            this.Id = artist.Id;
            this.Name = artist.Name;
            this.Description = artist.Description;
        }
    }
}