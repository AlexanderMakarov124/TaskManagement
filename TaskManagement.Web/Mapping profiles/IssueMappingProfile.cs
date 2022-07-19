using AutoMapper;
using TaskManagement.Domain.Dtos;
using TaskManagement.Domain.Models;

namespace TaskManagement.Web.Mapping_profiles;

/// <summary>
/// Issue mapping profile.
/// </summary>
public class IssueMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public IssueMappingProfile()
    {
        CreateMap<IssueDto, Issue>()
            .ReverseMap()
            .ForMember(dest => dest.HasSubIssues, opt => opt.MapFrom(issue => issue.SubIssues.Any()));
    }
}
