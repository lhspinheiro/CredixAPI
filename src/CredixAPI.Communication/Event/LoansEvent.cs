using CredixAPI.Communication.Request;
using CredixAPI.Domain.Entities;

namespace CredixAPI.Communication.Event;

public record LoansEvent(Loan entity);