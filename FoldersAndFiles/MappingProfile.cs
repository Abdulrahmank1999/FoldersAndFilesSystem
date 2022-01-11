using AutoMapper;
using FoldersAndFiles.Models;
using FoldersAndFiles.Models.Dto;

namespace FoldersAndFiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Folder, FolderDto>().ForMember(fd => fd.Name, opt => opt.MapFrom(fd => fd.Name))
                .ForMember(fd => fd.ContainerId, opt => opt.MapFrom(f => f.ContainerId)).ReverseMap();

            CreateMap<Models.File, FileDto>().ForMember(fd => fd.Name, opt => opt.MapFrom(fd => fd.Name))
                .ForMember(fd => fd.FolderId, opt => opt.MapFrom(f => f.FolderId)).ReverseMap();
        }
    }
}
