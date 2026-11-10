using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TritonDynamics.Facilitron.Api.Models;

public record CreateEventDto(
    [property: JsonPropertyName("external_system_event_id")] string ExternalSystemEventId,
    [property: JsonPropertyName("event_type")] string EventType,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("renter_email")] string RenterEmail,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("activity_type_id")] double ActivityTypeId,
    [property: JsonPropertyName("timeslots")] List<CreateTimeslotDto> Timeslots,
    [property: JsonPropertyName("attendance")] double Attendance = 0,
    [property: JsonPropertyName("renter_owner")] string? RenterOwner = null,
    [property: JsonPropertyName("event_log_message")] string? EventLogMessage = null
);

public record CreateTimeslotDto(
    [property: JsonPropertyName("external_system_timeslot_id")] string ExternalSystemTimeslotId,
    [property: JsonPropertyName("start_datetime")] DateTime StartDatetime,
    [property: JsonPropertyName("end_datetime")] DateTime EndDatetime,
    [property: JsonPropertyName("facility_u_id")] string FacilityUId,
    [property: JsonPropertyName("activity_name")] string? ActivityName = null
);

public record UpdateTimeslotDto(
    [property: JsonPropertyName("start_datetime")] DateTime StartDatetime,
    [property: JsonPropertyName("end_datetime")] DateTime EndDatetime,
    [property: JsonPropertyName("activity_name")] string? ActivityName = null,
    [property: JsonPropertyName("facility_u_id")] string? FacilityUId = null,
    [property: JsonPropertyName("event_log_message")] string? EventLogMessage = null
);

public record CancelEventDto(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("event_log_message")] string? EventLogMessage = null
);

public record PropertyDto(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("u_id")] string UId,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("zip")] string Zip,
    [property: JsonPropertyName("state")] string State,
    [property: JsonPropertyName("timezone")] string Timezone,
    [property: JsonPropertyName("properties")] List<string> Properties
);

public record FacilityDto(
    [property: JsonPropertyName("property_id")] string PropertyId,
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("u_id")] string UId,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("capacity")] double? Capacity,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("search_term")] string SearchTerm
);

public record TimeslotFacilityDto(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("u_id")] string UId,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("capacity")] double? Capacity,
    [property: JsonPropertyName("type")] string Type
);

public record EventDto(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("short_id")] string ShortId,
    [property: JsonPropertyName("rate_category")] string RateCategory,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("external_system_event_id")] string? ExternalSystemEventId,
    [property: JsonPropertyName("created_by_external_api")] bool CreatedByExternalApi,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("activity_type")] ActivityTypeDto? ActivityType,
    [property: JsonPropertyName("attendance")] double Attendance,
    [property: JsonPropertyName("property_id")] string PropertyId,
    [property: JsonPropertyName("timeslots")] List<TimeslotDto> Timeslots,
    [property: JsonPropertyName("submit_date")] string SubmitDate,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("property_timezone")] string PropertyTimezone,
    [property: JsonPropertyName("renter")] RenterDto? Renter
);

public record TimeslotDto(
    [property: JsonPropertyName("external_system_timeslot_id")] string? ExternalSystemTimeslotId,
    [property: JsonPropertyName("activity_name")] string? ActivityName,
    [property: JsonPropertyName("facility")] TimeslotFacilityDto Facility,
    [property: JsonPropertyName("start_datetime")] DateTime StartDatetime,
    [property: JsonPropertyName("end_datetime")] DateTime EndDatetime,
    [property: JsonPropertyName("status")] string Status
);

public record UpdatedTimeslotDto(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("external_system_timeslot_id")] string ExternalSystemTimeslotId,
    [property: JsonPropertyName("start_datetime")] DateTime StartDatetime,
    [property: JsonPropertyName("end_datetime")] DateTime EndDatetime,
    [property: JsonPropertyName("activity_name")] string? ActivityName,
    [property: JsonPropertyName("facility_u_id")] string FacilityUId
);

public record ActivityTypeDto(
    [property: JsonPropertyName("_id")] double Id,
    [property: JsonPropertyName("name")] string Name
);

public record RenterDto(
    [property: JsonPropertyName("_uid")] string Uid,
    [property: JsonPropertyName("renter_org")] string? RenterOrg,
    [property: JsonPropertyName("first_name")] string FirstName,
    [property: JsonPropertyName("last_name")] string LastName,
    [property: JsonPropertyName("email_address")] string EmailAddress
);

public record CreatedEventDto(
    [property: JsonPropertyName("external_system_event_id")] string ExternalSystemEventId,
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("short_id")] string ShortId,
    [property: JsonPropertyName("has_conflict")] bool HasConflict
);

public record CancelledEventDto(
    [property: JsonPropertyName("external_system_event_id")] string ExternalSystemEventId,
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("short_id")] string ShortId
);

public record BaseApiResponse(
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("message_code")] string MessageCode,
    [property: JsonPropertyName("invocation_id")] Guid InvocationId
);

public record CreateEventResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("event")] CreatedEventDto Event
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record GetEventByIdResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("event")] EventDto Event
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record CancelEventResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("event")] CancelledEventDto Event
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record UpdateTimeslotResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("timeslot")] UpdatedTimeslotDto Timeslot
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record GetEventsByFacilityIdResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("events")] List<EventDto> Events
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record GetEventsByPropertyIdResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("events")] List<EventDto> Events
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record GetAllPropertiesResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("properties")] List<PropertyDto> Properties
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record GetPropertyByIdResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("property")] PropertyDto Property
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record GetFacilitiesByPropertyIdResponse(
    string Message,
    string MessageCode,
    Guid InvocationId,
    [property: JsonPropertyName("facilities")] List<FacilityDto> Facilities
) : BaseApiResponse(Message, MessageCode, InvocationId);

public record ApiErrorResponse(
    [property: JsonPropertyName("invocation_id")] Guid InvocationId,
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("message_code")] string MessageCode
);
